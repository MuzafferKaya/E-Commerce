using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Staff
{
    [Table("Roles")]
    public class Role : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Permissions { get; set; } = string.Empty;
    }
}
