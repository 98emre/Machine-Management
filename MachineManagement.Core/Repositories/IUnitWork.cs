using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Repositories
{
    public interface IUnitWork
    {
        IDeviceRepository DeviceRepository { get; }
        IItemRepository ItemRepository { get; }

        Task CompleteAsync();
    }
}
