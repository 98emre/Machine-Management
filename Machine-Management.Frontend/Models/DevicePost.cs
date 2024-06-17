using System.ComponentModel.DataAnnotations;

namespace MachineManagement.Frontend.Models
{
    public class DevicePost
    {
        public required string Name { get; set; }

        [Required(ErrorMessage = "Add Date")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Add Date")]
        public required DateOnly Date { get; set; }
    }
}
