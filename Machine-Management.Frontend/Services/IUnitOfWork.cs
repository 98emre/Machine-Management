using MachineManagement.Core.Repositories;

namespace MachineManagement.Frontend.Services
{
    public interface IUnitOfWork
    {
        IDeviceService DeviceService { get; }
        IItemService ItemService { get; }
    }
}
