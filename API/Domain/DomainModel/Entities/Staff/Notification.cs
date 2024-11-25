using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Staff
{
    [Table("Notifications")]
    public class Notification : EntityBase
    {
        public long AccountId { get; set; }
        public StaffAccount Account { get; set; } = null!;
        public string Title { get; set; } = string.Empty;           // Bildirimin başlığı
        public string Content { get; set; } = string.Empty;         // Bildirimin içeriği
        public bool Seen { get; set; } = false;                     // Bildirimin görüldü olup olmadığını belirten durum
        public DateTime CreatedAt { get; set; } = DateTime.Now;     // Bildirimin oluşturulma tarihi
        public DateTime ExpriyDate { get; set; }                    // Bildirimin geçerlilik tarihi
    }
}
