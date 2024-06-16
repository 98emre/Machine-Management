using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Dtos.Device
{
    public class DevicePostDto
    {

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100")]
        public string Name { get; set; } = default!;

        [Required]
        public bool Status { get; set; }

        [Required]
        public DateOnly Date { get; set; }
    }
}
