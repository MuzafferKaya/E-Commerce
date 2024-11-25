using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
