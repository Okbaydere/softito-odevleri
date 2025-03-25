using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekProje.Model.DTOs.Jwt
{
    public class LoginResponceDto
    {
        public TokenDto Token { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
