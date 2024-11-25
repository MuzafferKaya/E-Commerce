using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;
using DomainModel.Enumerations;

namespace DomainModel.Entities.Order
{
    [Table("Orders")]
    public class Order : EntityBase
    {
        public long CustomerId { get; set; }                                    // Siparişi veren müşterinin ID'si
        public Customer.Customer Customer { get; set; } = null!;                // Siparişi veren müşteri nesnesi

        public long? CouponId { get; set; }                                     // Kullanılan kuponun ID'si (varsa)
        public Coupon.Coupon? Coupon { get; set; }                              // Kullanılan kuponun nesnesi (varsa)

        public decimal TotalAmount { get; set; }                                // Siparişin toplam tutarı     
        public OrderStatus Status { get; set; } = OrderStatus.Pending;          // Siparişin durumu (Bekliyor, Onaylandı, vb.)

        public DateTime? OrderApprodevAt { get; set; }                          // Siparişin onaylandığı tarih ve saat (varsa)   
        public DateTime? OrderDeliveredCarrierDate { get; set; }                // Siparişin kargoya verildiği tarih (varsa)
        public DateTime? OrderDeliveredCustomerDate { get; set; }               // Siparişin müşteriye teslim edildiği tarih (varsa)
        public DateTime CreatedAt { get; set; } = DateTime.Now;                 // Siparişin oluşturulma tarihi ve saati

        public long ShippingAddressId { get; set; }                             // Siparişin teslimat adresinin ID'si
        public Customer.CustomerAddress ShippingAddress { get; set; } = null!;  // Siparişin teslimat adresi (müşteriye ait adres)

        public ICollection<OrderItem> OrderItems { get; set; } = [];            // Siparişin öğeleri (ürünler)
        public ICollection<Payment.Payment> Payments { get; set; } = [];        // Siparişle ilişkili ödeme bilgileri
    }
}
