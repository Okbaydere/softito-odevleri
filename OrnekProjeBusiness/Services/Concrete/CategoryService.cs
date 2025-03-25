using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrnekProje.Dal.Context;
using OrnekProje.Dal.Repository.Concrete;
using OrnekProje.Model.DbViewModel;
using OrnekProje.Model.DTOs.Data;
using OrnekProjeBusiness.Services.Abstract;

namespace OrnekProjeBusiness.Services.Concrete;

public class CategoryService:RepositoryDto<Category,CategoryDto>,ICategoryService
{
    public CategoryService(OrnekProjeDbContext context, IMapper mapper,DbSet<Category> tentities) : base(context, mapper,tentities)
    {
    }
    
}