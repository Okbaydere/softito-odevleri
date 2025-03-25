using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrnekProje.Dal.Context;
using OrnekProje.Dal.Repository.Concrete;
using OrnekProje.Model.DbViewModel.Identity;
using OrnekProje.Model.DTOs.IdentityDto;
using OrnekProjeBusiness.Services.Abstract;

namespace OrnekProjeBusiness.Services.Concrete;

public class UserService:RepositoryDto<User,UserDto>,IUserServices
{
    public UserService(OrnekProjeDbContext context, IMapper mapper, DbSet<User> tentities) : base(context, mapper, tentities)
    {
    }
}