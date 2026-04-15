using Blazor26.DataAccess.DataAccess;
using Blazor26.Services;
using BlazorApp2026.Components;

using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

namespace BlazorApp2026
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JHaF5cWWdCekx0QHxbf1x2ZF1MYFpbRnNPIiBoS35RcEVgW3lccHRdRGdUWE1zVEFe");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFileMgt, FileMgt>();
            var app = builder.Build();

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
