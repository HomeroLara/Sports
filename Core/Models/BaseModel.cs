using System;
namespace Sports.Core.Models
{
    public class BaseModel
    {
        public Guid UniqueId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public BaseModel()
        {
            UniqueId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
