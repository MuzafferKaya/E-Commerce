namespace DomainModel.Entities.Base
{
    public class AuditableEntity : EntityBase
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
