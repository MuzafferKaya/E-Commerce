using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Staff
{
    [Table("StaffAccounts")]
    public class StaffAccount : AuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;       // Çalışanın adı
        public string LastName { get; set; } = string.Empty;        // Çalışanın soyadı
        public string PhoneNumber { get; set; } = string.Empty;     // Çalışanın telefon numarası
        public string Email { get; set; } = string.Empty;           // Çalışanın e-posta adresi
        public string PasswordHash { get; set; } = string.Empty;    // Çalışanın şifre hash'ı
        public string ProfileImg { get; set; } = string.Empty;      // Çalışanın profil resmi
        public DateTime RegisteredAt { get; set; } = DateTime.Now;  // Çalışanın sisteme kayıt olma tarihi
        public ICollection<Notification> Notifications { get; set; } = [];
    }
}
