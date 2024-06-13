namespace MachineManagement.Frontend.Models
{
    public class DeviceClient
    {

        private readonly List<Device> devices =
        [
            new()
            {
                Id = 1,
                Name = "Ice machine",
                Status = true,
                Date = new DateOnly(2022, 10, 2),
                Datas = []
            },

            new()
            {
                Id = 2,
                Name = "Black jack machine",
                Status = false,
                Date = new DateOnly(2000, 2, 2),
                Datas = []
            },

            new()
            {
                Id = 3,
                Name = "Slot Machine",
                Status = true,
                Date = new DateOnly(2012, 4, 12),
                Datas = []
            }

        ];

        public Device[] Devices() => [.. devices];

    }
}
