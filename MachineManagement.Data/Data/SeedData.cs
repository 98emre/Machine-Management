using Bogus;
using MachineManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Data.Data
{
    public class SeedData
    {
        private static Faker faker;

        public static async Task InitAsync(MachineManagementAPIContext context)
        {
            if(! await context.Device.AnyAsync())
            {
                faker = new Faker();

                var devices = GenerateDevice(3);
                await context.AddRangeAsync(devices);

                var items = GenerateItems(devices, 3);
                await context.AddRangeAsync(items);

                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<Device> GenerateDevice(int count)
        {
            var devices = new List<Device>();

            for(int i = 0; i<count; i++)
            {
                var device = new Device
                {
                    Name = faker.Random.Word(),
                    Status = faker.Random.Bool(),
                    Date = faker.Date.RecentDateOnly(),
                };

                devices.Add(device);
            }

            return devices;
        }

        private static IEnumerable<Item> GenerateItems(IEnumerable<Device> devices, int nrOfItems) 
        {
            var items = new List<Item>();

            foreach (var device in devices)
            {
                for(int i = 0; i<nrOfItems; i++)
                {
                    var item = new Item
                    {
                        Device = device,
                        Name = faker.Random.Word(),
                        Price = faker.Random.Number(),
                    };

                    items.Add(item);

                }
            }

            return items;
        }
    }
}
