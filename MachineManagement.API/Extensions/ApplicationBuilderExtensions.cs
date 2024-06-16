using MachineManagement.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace MachineManagement.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MachineManagementAPIContext>();

                try
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();

                    await SeedData.InitAsync(context);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

        }
    }
}
