using OrnekProje.Model.Core;
using OrnekProje.Model.DbViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekProje.Model.DTOs.Data
{
    public class CategoryDto:EntityBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
