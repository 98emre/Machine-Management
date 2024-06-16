using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MachineManagement.Data.Data;
using MachineManagement.API.Extensions;

namespace MachineManagement.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MachineManagementAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MachineManagementAPIContext") ?? throw new InvalidOperationException("Connection string 'MachineManagementAPIContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //await app.SeedDataAsync();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
