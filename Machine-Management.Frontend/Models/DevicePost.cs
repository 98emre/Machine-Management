namespace MachineManagement.Frontend.Models
{
    public class DevicePost
    {
        public required string Name { get; set; }

        public bool Status { get; set; }

        public required DateOnly Date { get; set; }
    }
}
