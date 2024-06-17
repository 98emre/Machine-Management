using Machine_Management.Frontend.Components;
using MachineManagement.Frontend.Models;
using MachineManagement.Frontend.Services;
using Microsoft.Extensions.Configuration;

namespace Machine_Management.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddHttpClient<IDeviceService, DeviceService>(client =>
            {
                var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
                if (string.IsNullOrEmpty(apiBaseUrl))
                {
                    throw new InvalidOperationException("ApiBaseUrl configuration is missing.");
                }
                client.BaseAddress = new Uri(apiBaseUrl);
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
            });

            builder.Services.AddSingleton<DeviceClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
