using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrnekProje.Dal.Context;
using OrnekProje.Dal.Repository.Concrete;
using OrnekProje.Model.DbViewModel;
using OrnekProje.Model.DTOs.Data;
using OrnekProjeBusiness.Services.Abstract;

namespace OrnekProjeBusiness.Services.Concrete;

public class ProductService:RepositoryDto<Product,ProductDto>, IProductService
{
    public ProductService(OrnekProjeDbContext context, IMapper mapper, DbSet<Product> tentities) : base(context, mapper, tentities)
    {
    }
}