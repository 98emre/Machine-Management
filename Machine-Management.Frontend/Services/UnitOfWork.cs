namespace MachineManagement.Frontend.Services
{
    public class UnitOfWork : IUnitOfWork
    {
       
        private readonly HttpClient _httpClient;

        public UnitOfWork(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IDeviceService DeviceService => new DeviceService(_httpClient);

        public IItemService ItemService => new ItemService(_httpClient);

    }
}
