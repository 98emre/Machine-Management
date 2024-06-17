using MachineManagement.Core.Dtos.ItemDtos;
using MachineManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Dtos.Device
{
    public class DeviceDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Choose status")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Add Date")]
        public DateOnly Date { get; set; }

        public ICollection<ItemWithIdDto> Items { get; set; } = new List<ItemWithIdDto>();
    }
}
