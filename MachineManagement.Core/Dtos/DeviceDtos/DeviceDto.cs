using MachineManagement.Core.Dtos.ItemDtos;
using MachineManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Dtos.Device
{
    public class DeviceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public bool Status { get; set; }

        public DateOnly Date { get; set; }

        public ICollection<ItemWithIdDto> Items { get; set; } = new List<ItemWithIdDto>();
    }
}
