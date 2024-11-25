using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Order
{
    [Table("OrderItems")]
    public class OrderItem : EntityBase
    {
        public long OrderId { get; set; }                       // Siparişin ID'si
        public Order Order { get; set; } = null!;               // Siparişin nesnesi
        public long ProductId { get; set; }                     // Ürünün ID'si
        public Product.Product Product { get; set; } = null!;   // Ürün nesnesi
        public decimal Price { get; set; }                      // Ürünün birim fiyatı
        public int Quantity { get; set; }                       // Ürünün sipariş edilen adedi
    }
}
