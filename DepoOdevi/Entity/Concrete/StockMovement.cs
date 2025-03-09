using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class StockMovement
    {
        [Key]
        public int StockMovementId { get; set; }

        [Required(ErrorMessage = "Ürün seçimi zorunludur.")]
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Çalışan seçimi zorunludur.")]
        [Display(Name = "Çalışan")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Hareket tipi zorunludur.")]
        [StringLength(50, ErrorMessage = "Hareket tipi en fazla 50 karakter olabilir.")]
        [Display(Name = "Hareket Tipi")]
        public string MovementType { get; set; } // Giriş, Çıkış, Sayım, Satış, İade

        [Required(ErrorMessage = "Miktar zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Miktar 0'dan büyük olmalıdır.")]
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Hareket tarihi zorunludur.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hareket Tarihi")]
        public DateTime MovementDate { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Birim Fiyat")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? UnitPrice { get; set; } // Opsiyonel, hareket anındaki fiyat

        // İlişkiler
        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
    }
}