using System.Threading.Tasks;
using Blazor26.DataAccess.DataAccess;
using Blazor26.Services;
using Blazor26.Services.BusinessModels;
using BlazorApp2026.Components;

using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

namespace BlazorApp2026
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JHaF5cWWdCekx0QHxbf1x2ZF1MYFpbRnNPIiBoS35RcEVgW3lccHRdRGdUWE1zVEFe");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton<MLService>();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFileMgt, FileMgt>();
            var app = builder.Build();

            
            using (var scope = app.Services.CreateScope())
            {
                var mlService = scope.ServiceProvider.GetRequiredService<MLService>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var sales = await unitOfWork.SalesRepo.ListofSalesDataAsync();

                if (sales.Any())
                {
                    var data = sales.Select(s => new SalesData
                    {
                        Month = s.MonthName.Month,
                        SalesAmount = (float)s.SalesAmount
                    }).ToList();

                    mlService.Train(data);
                    Console.WriteLine("Model trained at startup");
                }
                else
                {
                    Console.WriteLine("No data available for training");
                }
            }



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
