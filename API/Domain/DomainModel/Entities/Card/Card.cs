using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Card
{
    [Table("Cards")]
    public class Card : EntityBase
    {
        public long CustomerId { get; set; }                        // Sepetin ait olduğu müşteri ID'si
        public Customer.Customer Customer { get; set; } = null!;    // Müşteri nesnesi

        public ICollection<CardItem> CardItems { get; set; } = [];  // Sepetteki ürünlerin koleksiyonu
    }
}
