using MachineManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device> GetAsync(int id, bool includeGames);
        Task<bool> AnyAsync(int id);
        void Add(Device device);
        void Update(Device device);
        void Remove(Device device);
    }
}
