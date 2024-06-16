using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MachineManagement.Core.Entities;

namespace MachineManagement.Data.Data
{
    public class MachineManagementAPIContext : DbContext
    {
        public MachineManagementAPIContext (DbContextOptions<MachineManagementAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MachineManagement.Core.Entities.Device> Device { get; set; } = default!;
        public DbSet<MachineManagement.Core.Entities.Item> Item { get; set; } = default!;
    }
}
