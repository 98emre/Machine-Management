using MachineManagement.Frontend.Models;

namespace MachineManagement.Frontend.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetDevicesAsync();
        Task<Device> GetDeviceAsync(int id);
        Task AddDeviceAsync(DevicePost devicePost);
        Task UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(int id);
    }
}
