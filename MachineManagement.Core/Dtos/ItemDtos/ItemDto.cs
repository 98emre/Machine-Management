using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Dtos.ItemDtos
{
    public class ItemDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Price { get; set; }

        public int DeviceId { get; set; }
    }
}
