using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Shipping
{
    [Table("ShippingProviders")]
    public class ShippingProvider : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
    }
}
