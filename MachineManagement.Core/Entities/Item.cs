using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Price { get; set; }

        [ForeignKey("DeviceId")]
        public int DeviceId { get; set; }

        public Device? Device { get; set; }
    }
}
