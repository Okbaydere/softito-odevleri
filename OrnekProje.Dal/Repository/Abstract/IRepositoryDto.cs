using OrnekProje.Model.DTOs.Jwt;
using OrnekProje.Model.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;

namespace OrnekProje.Dal.Repository.Abstract
{
    public interface IRepositoryDto<TentityDTO> where TentityDTO:class,new()
    {
        Task<ResponseDto<List<TentityDTO>>> GetAll();
        Task<ResponseDto<List<TentityDTO>>> GetAllIgnoreFilter();
        
        Task <ResponseDto<TentityDTO>> GetById(int id);
        Task<ResponseDto<TentityDTO>> Create(TentityDTO entity);
        
        Task<ResponseDto<TentityDTO>> Update(int id, TentityDTO entity);
        Task<ResponseDto<TentityDTO>> Delete(int id);
        
    }
}
