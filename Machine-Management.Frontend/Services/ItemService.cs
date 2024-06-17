using MachineManagement.Frontend.Models;

namespace MachineManagement.Frontend.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddItemAsync(ItemPost itemPost) => await _httpClient.PostAsJsonAsync("api/items", itemPost);

        public async Task DeleteItemAsync(int id) => await _httpClient.DeleteAsync($"api/items/{id}");

        public async Task<IEnumerable<Item>> GetDeviceItemsAsync(int deviceId) => await _httpClient.GetFromJsonAsync<IEnumerable<Item>>($"api/items/device/{deviceId}");

        public async Task<Item> GetItemAsync(int id) => await _httpClient.GetFromJsonAsync<Item>($"api/items/{id}");

        public async Task<IEnumerable<Item>> GetItemsAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Item>>("api/items");

        public async Task UpdateItemAsync(Item item) => await _httpClient.PutAsJsonAsync($"api/items/{item.Id}", item);
    }
}
