namespace MachineManagement.Frontend.Models
{
    public class Device
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public bool Status { get; set; }

        public required DateOnly Date { get; set; }
    }
}
