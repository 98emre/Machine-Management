using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MachineManagement.Frontend.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Choose Status")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Add Date")]
        public DateOnly Date { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
