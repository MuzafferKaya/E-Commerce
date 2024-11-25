using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Customer
{
    [Table("Customers")]
    public class Customer : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;               // Müşterinin adı
        public string LastName { get; set; } = string.Empty;                // Müşterinin soyadı
        public string PhoneNumber { get; set; } = string.Empty;             // Müşterinin telefon numarası
        public string Email { get; set; } = string.Empty;                   // Müşterinin e-posta adresi
        public string PasswordHash { get; set; } = string.Empty;            // Müşterinin şifre hash'i
        public DateTime RegisteredAt { get; set; } = DateTime.Now;          // Müşterinin kayıt olduğu tarih ve saat

        public bool IsEmailVerified { get; set; } = false;                  // Müşterinin e-posta adresi doğrulandı mı?
        public string EmailVerificationCode { get; set; } = string.Empty;   // Müşteriye gönderilen doğrulama kodu
        public DateTime? EmailVerificationCodeExpiration { get; set; }      // E-posta doğrulama kodunun geçerlilik tarihi

        public string RefreshToken { get; set; } = string.Empty;            // Müşterinin refresh token'ı
        public DateTime RefreshTokenExpiration { get; set; }                // Refresh token'ın geçerlilik tarihi

        public ICollection<CustomerAddress> Addresses { get; set; } = [];   // Müşteriye ait adresler
    }
}
