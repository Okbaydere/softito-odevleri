using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

     
        public string Description { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0'dan küçük olamaz.")]
        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Minimum stok miktarı zorunludur.")]
        [Range(0, int.MaxValue, ErrorMessage = "Minimum stok miktarı 0'dan küçük olamaz.")]
        [Display(Name = "Minimum Stok")]
        public int MinimumStock { get; set; }

        [Required(ErrorMessage = "Alış fiyatı zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Alış fiyatı 0'dan küçük olamaz.")]
        [Display(Name = "Alış Fiyatı")]
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Satış fiyatı zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Satış fiyatı 0'dan küçük olamaz.")]
        [Display(Name = "Satış Fiyatı")]
        [DataType(DataType.Currency)]
        public decimal SalePrice { get; set; }

        [Display(Name = "Son Alım Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastPurchaseDate { get; set; }

      
        public string Barcode { get; set; }

      
        public string Brand { get; set; }

        // Foreign Keys
        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçimi zorunludur.")]
        [Display(Name = "Tedarikçi")]
        public int SupplierId { get; set; }

        [Display(Name = "Kargo")]
        public int? ShippingId { get; set; }

        // İlişkiler
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }
    }
}