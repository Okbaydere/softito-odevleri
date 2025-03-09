using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Firma adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Firma adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "İletişim kişisi zorunludur.")]
        [StringLength(50, ErrorMessage = "İletişim kişisi en fazla 50 karakter olabilir.")]
        [Display(Name = "İletişim Kişisi")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [StringLength(50, ErrorMessage = "E-posta adresi en fazla 50 karakter olabilir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [StringLength(200, ErrorMessage = "Adres en fazla 200 karakter olabilir.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        // İlişkiler
        public virtual ICollection<Product> Products { get; set; }
    }
}