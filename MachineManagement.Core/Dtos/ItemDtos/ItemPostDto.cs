using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Dtos.ItemDtos
{
    public class ItemPostDto
    {

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50")]
        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }

        public int DeviceId { get; set; }
    }
}
