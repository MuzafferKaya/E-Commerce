using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Coupon
{
    [Table("ProductCoupons")]
    public class ProductCoupon : EntityBase
    {
        public long ProductId { get; set; }                     // İlgili ürünün ID'si
        public Product.Product Product { get; set; } = null!;   // Ürün nesnesi
        public long CouponId { get; set; }                      // İlgili kuponun ID'si
        public Coupon Coupon { get; set; } = null!;             // Kupon nesnesi
        public bool IsApplicable { get; set; }                  // Kuponun bu ürüne uygulanıp uygulanamayacağını belirten flag.
    }
}
