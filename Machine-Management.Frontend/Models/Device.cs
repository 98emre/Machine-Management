using System.Collections;

namespace MachineManagement.Frontend.Models
{
    public class Device
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public DateOnly Date { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
