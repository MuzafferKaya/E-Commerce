using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;
using DomainModel.Enumerations;

namespace DomainModel.Entities.Payment
{
    [Table("Payments")]
    public class Payment : EntityBase
    {
        public long OrderId { get; set; }                                   // İlgili siparişin ID'si
        public Order.Order Order { get; set; } = null!;                     // Siparişle ilişkili

        public decimal Amount { get; set; }                                 // Ödenen tutar
        public PaymentMethod PaymentMethod { get; set; }                    // Ödeme yöntemi (Kredi kartı, Banka kartı vb.)
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;  // Ödeme durumu (Bekliyor, Başarılı, Başarısız vb.)
        public DateTime PaymentDate { get; set; } = DateTime.Now;           // Ödeme tarihi
        public string TransactionReference { get; set; } = string.Empty;    // Ödeme işlem referans numarası

        public DateTime? RefundDate { get; set; }                           // Geri ödeme tarihi (İade işlemi yapılmışsa)
        public string? RefundTransactionReference { get; set; }             // Geri ödeme işlem referans numarası
    }
}
