using System.ComponentModel.DataAnnotations;

namespace MachineManagement.Frontend.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50")]
        public string? Name { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100")]
        public double Price { get; set; }

        public int DeviceId { get; set; }
    }
}
