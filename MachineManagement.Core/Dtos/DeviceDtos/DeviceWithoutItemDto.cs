using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Dtos.Device
{
    public class DeviceWithoutItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public bool Status { get; set; }

        public DateOnly Date { get; set; }
    }
}
