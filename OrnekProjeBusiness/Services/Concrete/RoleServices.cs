using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrnekProje.Dal.Context;
using OrnekProje.Dal.Repository.Concrete;
using OrnekProje.Model.DbViewModel.Identity;
using OrnekProje.Model.DTOs.IdentityDto;
using OrnekProjeBusiness.Services.Abstract;

namespace OrnekProjeBusiness.Services.Concrete;

public class RoleServices:RepositoryDto<Role,RoleDto>, IRoleServices
{
    public RoleServices(OrnekProjeDbContext context, IMapper mapper, DbSet<Role> tentities) : base(context, mapper, tentities)
    {
    }
}