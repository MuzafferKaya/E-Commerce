using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Product
{
    [Table("Products")]
    public class Product : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;            // Ürünün adı
        public string SKU { get; set; } = string.Empty;             // Ürünün benzersiz stok kodu
        public string Description { get; set; } = string.Empty;     // Ürünün açıklaması
        public decimal Price { get; set; }                          // Ürünün fiyatı
        public int Quantity { get; set; }                           // Ürünün stok adedi
        public long CategoryId { get; set; }                        // Ürünün ait olduğu kategorinin ID'si
        public Category Category { get; set; } = null!;             // Ürünün ait olduğu kategori
        public bool IsPublished { get; set; }                       // Ürünün yayında olup olmadığını belirten boolean değer
        public ICollection<Gallery> Galleries { get; set; } = [];   // Ürüne ait görsellerin listesi (galeri)
    }
}
