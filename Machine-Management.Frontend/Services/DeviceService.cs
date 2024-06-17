using MachineManagement.Frontend.Models;

namespace MachineManagement.Frontend.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly HttpClient _httpClient;

        public DeviceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddDeviceAsync(DevicePost devicePost) => await _httpClient.PostAsJsonAsync("api/devices", devicePost);

        public async Task DeleteDeviceAsync(int id) => await _httpClient.DeleteAsync($"api/devices/{id}");

        public async Task<Device> GetDeviceAsync(int id) => await _httpClient.GetFromJsonAsync<Device>($"api/devices/{id}");

        public async Task<IEnumerable<Device>> GetDevicesAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Device>>("api/devices");
        
        public async Task UpdateDeviceAsync(Device device) => await _httpClient.PutAsJsonAsync($"api/devices/{device.Id}", device);
    }
}
