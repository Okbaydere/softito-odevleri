using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }

        [Required(ErrorMessage = "Kargo firması zorunludur.")]
        [StringLength(50, ErrorMessage = "Kargo firması en fazla 50 karakter olabilir.")]
        [Display(Name = "Kargo Firması")]
        public string CargoCompany { get; set; }

        [Required(ErrorMessage = "Takip numarası zorunludur.")]
        [StringLength(50, ErrorMessage = "Takip numarası en fazla 50 karakter olabilir.")]
        [Display(Name = "Takip Numarası")]
        public string TrackingNumber { get; set; }

        [Required(ErrorMessage = "Teslimat adresi zorunludur.")]
        [StringLength(200, ErrorMessage = "Teslimat adresi en fazla 200 karakter olabilir.")]
        [Display(Name = "Teslimat Adresi")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Gönderim tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Gönderim Tarihi")]
        public DateTime ShipmentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Teslim Tarihi")]
        public DateTime? ArriveDate { get; set; }

        [Required(ErrorMessage = "Alıcı adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Alıcı adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Alıcı Adı")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "Alıcı telefonu zorunludur.")]
        [StringLength(20, ErrorMessage = "Alıcı telefonu en fazla 20 karakter olabilir.")]
        [Display(Name = "Alıcı Telefonu")]
        public string ReceiverPhone { get; set; }

        [Required(ErrorMessage = "Durum zorunludur.")]
        [StringLength(50, ErrorMessage = "Durum en fazla 50 karakter olabilir.")]
        [Display(Name = "Durum")]
        public string Status { get; set; } // Hazırlanıyor, Kargoya Verildi, Teslim Edildi

        // İlişkiler
        public virtual ICollection<Product> Products { get; set; }
    }
}