using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;
using DomainModel.Enumerations;

namespace DomainModel.Entities.Shipping
{
    [Table("Shippings")]
    public class Shipping : EntityBase
    {
        public long OrderId { get; set; }                                       // İlgili siparişin ID'si
        public Order.Order Order { get; set; } = null!;                         // Siparişle ilişkili

        public long ShippingProviderId { get; set; }                            // Kargo firması ID'si
        public ShippingProvider ShippingProvider { get; set; } = null!;         // Kargo firması bilgisi

        public decimal ShippingCost { get; set; }                               // Kargo ücreti
        public DateTime ShippingDate { get; set; }                              // Kargonun gönderilme tarihi
        public DateTime EstimatedDeliveryDate { get; set; }                     // Tahmini teslimat tarihi
        public DateTime? ActualDeliveryDate { get; set; }                       // Gerçek teslimat tarihi

        public ShippingStatus Status { get; set; } = ShippingStatus.Pending;    // Kargonun durumu: Hazırlanıyor, Kargoya Verildi, Teslim Edildi, vb.

        public string TrackingCode { get; set; } = string.Empty;                // Kargo takip numarası
    }
}
