using MachineManagement.Frontend.Models;

namespace MachineManagement.Frontend.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<IEnumerable<Item>> GetDeviceItemsAsync(int deviceId);
        Task<Item> GetItemAsync(int id);
        Task AddItemAsync(ItemPost itemPost);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
    }
}
