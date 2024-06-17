using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Dtos.ItemDtos
{
    public class ItemDto
    {
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50")]
        public string? Name { get; set; }

        [Required]
        [Range(1, 100,ErrorMessage = "Price must be between 1 and 100")]
        public double Price { get; set; }

        public int DeviceId { get; set; }
    }
}
