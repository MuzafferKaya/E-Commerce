using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Product
{
    [Table("Categories")]
    public class Category : AuditableEntity
    {
        public long? ParentId { get; set; }                         // Kategorinin üst kategori ID'si (eğer varsa)
        public string Name { get; set; } = string.Empty;            // Kategorinin adı
        public string Description { get; set; } = string.Empty;     // Kategorinin açıklaması
        public bool IsActive { get; set; } = true;                  // Kategorinin aktif olup olmadığını belirten durum
        public ICollection<Product> Products { get; set; } = [];    // Bu kategoriye ait olan ürünlerin koleksiyonu
    }
}
