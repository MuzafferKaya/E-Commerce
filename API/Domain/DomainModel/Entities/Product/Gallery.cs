using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Product
{
    [Table("Galleries")]
    public class Gallery : AuditableEntity
    {
        public long ProductId { get; set; }                     // Galeriye ait olan ürünün ID'si
        public Product Product { get; set; } = null!;           // İlgili ürünün referansı
        public string ImagePath { get; set; } = string.Empty;   // Görselin dosya yolu
        public bool IsThumbnail { get; set; }                   // Bu görselin küçük resim (thumbnail) olup olmadığını belirler
        public int DisplayOrder { get; set; }                   // Görsellerin sıralama düzeni
    }
}
