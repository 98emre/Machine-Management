using MachineManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Core.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetAsync(int id);
        Task<bool> AnyAsync(int id);
        void Add(Item item);
        void Update(Item item);
        void Remove(Item item);
    }
}
