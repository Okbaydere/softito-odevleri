using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [StringLength(200, ErrorMessage = "Adres en fazla 200 karakter olabilir.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [StringLength(50, ErrorMessage = "E-posta adresi en fazla 50 karakter olabilir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "Uyruk en fazla 50 karakter olabilir.")]
        [Display(Name = "Uyruk")]
        public string Nation { get; set; }

        [Required(ErrorMessage = "Görev zorunludur.")]
        [StringLength(100, ErrorMessage = "Görev en fazla 100 karakter olabilir.")]
        [Display(Name = "Görev")]
        public string Task { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        // İlişkiler
        public virtual ICollection<StockMovement> StockMovements { get; set; }
    }
}
