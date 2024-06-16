using MachineManagement.Core.Repositories;
using MachineManagement.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MachineManagementAPIContext _context;

        public UnitOfWork(MachineManagementAPIContext context)
        {
            _context = context;
        }

        public IDeviceRepository DeviceRepository => new DeviceRepository(_context);

        public IItemRepository ItemRepository => new ItemRepository(_context);

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        
    }
}
