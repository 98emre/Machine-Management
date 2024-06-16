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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly MachineManagementAPIContext _context;

        public DeviceRepository(MachineManagementAPIContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Device device) => _context.Add(device);

        public async Task<bool> AnyAsync(int id) => await _context.Device.AnyAsync(d => d.Id == id);

        public async Task<IEnumerable<Device>> GetAllAsync() => await _context.Device.ToListAsync();

        public async Task<Device> GetAsync(int id) => await _context.Device.FirstOrDefaultAsync(d => d.Id == id);

        public void Remove(Device device) => _context.Device.Remove(device);

        public void Update(Device device) => _context.Device.Update(device);
    }
}
