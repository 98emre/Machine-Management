using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Entities
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public bool Status { get; set; }

        public DateOnly Date { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
