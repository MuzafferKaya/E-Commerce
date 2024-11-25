using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Card
{
    [Table("CardItems")]
    public class CardItem : EntityBase
    {
        public long CardId { get; set; }                        // Sepetle ilişkilendirilen ID
        public Card Card { get; set; } = null!;                 // Sepet nesnesi
        public long ProductId { get; set; }                     // Sepetteki ürünün ID'si
        public Product.Product Product { get; set; } = null!;   // Ürün nesnesi
        public int Quantity { get; set; }                       // Sepetteki ürünün adedi
    }
}
