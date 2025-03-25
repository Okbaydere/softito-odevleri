using AutoMapper;
using OrnekProje.Model.DbViewModel;
using OrnekProje.Model.DbViewModel.Identity;
using OrnekProje.Model.DTOs.Data;
using OrnekProje.Model.DTOs.IdentityDto;

namespace OrnekProjeBusiness.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
        
    }
}