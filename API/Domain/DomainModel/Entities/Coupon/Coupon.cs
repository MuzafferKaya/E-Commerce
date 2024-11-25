using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;
using DomainModel.Enumerations;

namespace DomainModel.Entities.Coupon
{
    [Table("Coupons")]
    public class Coupon : AuditableEntity
    {
        public string Code { get; set; } = string.Empty;                            // Kuponun benzersiz kodu
        public string Description { get; set; } = string.Empty;                     // Kuponun açıklaması

        public DiscountType DiscountType { get; set; }                              // Kuponun indirim tipi (örneğin, yüzde veya tutar bazlı indirim)
        public decimal DiscountValue { get; set; }                                  // Kuponun indirim miktarı

        public decimal MinOrderValue { get; set; } = 0;                             // Kuponun kullanılabilmesi için gereken minimum sipariş tutarı

        public DateTime StartDate { get; set; }                                     // Kuponun geçerli olmaya başladığı tarih
        public DateTime EndDate { get; set; }                                       // Kuponun geçerliliğinin sona erdiği tarih

        public int UsageLimit { get; set; } = 1;                                    // Kuponun toplam kullanım limiti, kaç kez kullanılabileceğini belirler
        public int UsedCount { get; set; } = 0;                                     // Kuponun şu ana kadar kaç kez kullanıldığını takip eder

        public CouponStatus Status { get; set; }                                    // Kuponun mevcut durumu (Aktif, Pasif vb.)
        public ICollection<ProductCoupon> ApplicableProducts { get; set; } = [];    // Bu kuponun geçerli olduğu ürünler
    }
}
