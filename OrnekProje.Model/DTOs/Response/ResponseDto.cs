using OrnekProje.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekProje.Model.DTOs.Response
{
    public class ResponseDto<T> where T:class
    {
        public T? Data { get; set; }
        public StatusCode StatusCode { get; set; }
        public string Messager { get; set; }
        public List<string> Errors { get; set; }
    }
}
