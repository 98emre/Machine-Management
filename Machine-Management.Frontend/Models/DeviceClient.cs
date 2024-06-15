using System.Xml.Linq;

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
                Items = []
            },

            new()
            {
                Id = 2,
                Name = "Black jack machine",
                Status = false,
                Date = new DateOnly(2000, 2, 2),
                Items = []
            },

            new()
            {
                Id = 3,
                Name = "Slot Machine",
                Status = true,
                Date = new DateOnly(2012, 4, 12),
                Items = []
            }
        ];

        public Device[] Devices() => [.. devices];

        public void AddDevice(Device addDevice) 
        {
            var device = new Device
            {
                Id = devices.Count + 1,
                Name = addDevice.Name,
                Status = addDevice.Status,
                Date = addDevice.Date,
            };

            devices.Add(device);
        }

        public void RemoveDevice(int id) 
        {
            Device? device = devices.Find(d => d.Id == id);
            ArgumentNullException.ThrowIfNull(device);
            devices.Remove(device);
        }

        public void UpdateDevice(Device device)
        {
            var existingDevice = devices.Find(d => d.Id ==  device.Id);
            ArgumentNullException.ThrowIfNull(existingDevice);

            existingDevice.Status = device.Status;
            existingDevice.Name = device.Name;
            existingDevice.Date = device.Date;
        }

        public Device GetDevice(int id)
        {
            var existingDevice = devices.Find(d => d.Id == id);
            ArgumentNullException.ThrowIfNull(existingDevice);

            return existingDevice;
        }

        public void AddItem(int id, Item item)
        {
            var device = devices.Find(d => d.Id == id);

            ArgumentNullException.ThrowIfNull(device);

            var addItem = new Item
            {
                Id = device.Items.Count() + 1,
                Name = item.Name,
                Price = item.Price,
            };

            device.Items.Add(addItem);
        }

        public void RemoveItem(int deviceId, int itemId)
        {
            var device = devices.FirstOrDefault(d => d.Id == deviceId);

            ArgumentNullException.ThrowIfNull(device);

            var item = device.Items.FirstOrDefault(i =>  i.Id == itemId);
            ArgumentNullException.ThrowIfNull(item);

            device.Items.Remove(item);
        }

        public void UpdateItem(int deviceId, int itemId, Item updateItem)
        {
            var device = devices.FirstOrDefault(d => d.Id == deviceId);
            ArgumentNullException.ThrowIfNull(device);

            var item = device.Items.FirstOrDefault(i => i.Id == itemId);
            ArgumentNullException.ThrowIfNull(item);

            item.Name = updateItem.Name;
            item.Price = updateItem.Price;
        }
    }
}
