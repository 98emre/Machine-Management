using MachineManagement.Core.Entities;
using MachineManagement.Core.Repositories;
using MachineManagement.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly MachineManagementAPIContext _context;

        public ItemRepository(MachineManagementAPIContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Item item) => _context.Add(item);

        public async Task<bool> AnyAsync(int id) => await _context.Item.AnyAsync(i => i.Id == id);

        public async Task<IEnumerable<Item>> GetAllAsync() => await _context.Item.ToListAsync();

        public async Task<Item> GetAsync(int id) => await _context.Item.FirstOrDefaultAsync(i => i.Id == id); 
      
        public void Remove(Item item) => _context.Item.Remove(item);

        public void Update(Item item) => _context.Item.Update(item);
    }
}
