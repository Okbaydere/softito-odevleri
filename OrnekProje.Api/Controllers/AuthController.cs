using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrnekProje.Model.DbViewModel.Identity;
using OrnekProje.Model.DTOs.IdentityDto;
using OrnekProje.Model.DTOs.Jwt;
using OrnekProje.Model.DTOs.Response;
using OrnekProjeBusiness.Services.Abstract;

namespace OrnekProje.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : Controller
{
    private readonly IUserServices _userService;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMapper _mapper;

    public AuthController(IUserServices userService, IConfiguration configuration, IMapper mapper,
        IPasswordHasher<User> passwordHasher)
    {
        _userService = userService;
        _configuration = configuration;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

[HttpPost("login")]
[AllowAnonymous]
public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
{
    var userResponse = await _userService.GetAll();
    if (userResponse.StatusCode != Model.Enums.StatusCode.Success)
    {
        return BadRequest(new ResponseDto<LoginResponceDto>
        {
            StatusCode = userResponse.StatusCode,
            Messager = userResponse.Messager
        });
    }

    var userdto = userResponse.Data.FirstOrDefault(x => x.UserName == request.UserName);
    if (userdto == null)
    {
        return Unauthorized(new ResponseDto<LoginResponceDto>
        {
            StatusCode = Model.Enums.StatusCode.Error,
            Messager = "Kullanıcı adı veya şifre Hatalı"
        });
    }

    var user = _mapper.Map<User>(userdto);
    if (string.IsNullOrEmpty(user.PasswordHash) ||
        _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) !=
        PasswordVerificationResult.Success)
    {
        return Unauthorized(new ResponseDto<LoginResponceDto>
        {
            StatusCode = Model.Enums.StatusCode.Error,
            Messager = "Şifre Hatalı"
        });
    }

    var token = GenerateToken(userdto);
    var response = new LoginResponceDto
    {
        Token = token,
        UserId = userdto.Id,
        UserName = userdto.UserName,
        Roles = userdto.Roles
    };

    return Ok(new ResponseDto<LoginResponceDto>
    {
        Data = response,
        StatusCode = Model.Enums.StatusCode.Success,
        Messager = "Login Başarılı"
    });
}

private TokenDto GenerateToken(UserDto userDto)
{
    var jwtSetting = _configuration.GetSection("jwtSetting");
    var secretKey = jwtSetting["secretKey"] ?? throw new ArgumentNullException("jwt secret key eksik");

    if (!int.TryParse(jwtSetting["ExpiryInMinutes"], out var expiryInMinutes))
    {
        expiryInMinutes = 60; // Varsayılan değer
    }

    var key = Encoding.UTF8.GetBytes(secretKey);
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
        new Claim(ClaimTypes.Name, userDto.UserName),
        new Claim(ClaimTypes.Email, userDto.Email),
    };

    if (userDto.Roles != null)
    {
        claims.AddRange(userDto.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
    }

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
        Issuer = jwtSetting["Issuer"],
        Audience = jwtSetting["Audience"],
        SigningCredentials =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);

    return new TokenDto
    {
        AccessToken = tokenHandler.WriteToken(token),
        AccessTokenExpiration = tokenDescriptor.Expires.Value,
        RefreshToken = string.Empty,
        RefreshTokenExpiration = DateTime.MinValue
    };
}
}
