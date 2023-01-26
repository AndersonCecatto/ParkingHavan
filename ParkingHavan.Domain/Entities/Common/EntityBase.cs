using System.ComponentModel.DataAnnotations;

namespace ParkingHavan.Domain.Entities.Common
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
