using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Staff
{
    [Table("StaffRoles")]
    public class StaffRole : EntityBase
    {
        public long AccountId { get; set; }
        public StaffAccount Account { get; set; } = null!;
        public long RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
