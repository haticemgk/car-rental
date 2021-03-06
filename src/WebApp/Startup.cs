using Application.Infrastructure.Persistence;
using Application.Services;
using Application.Services.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<CarRentalDbContext>();
            services.AddScoped<ICarRentalDbContext>(provider => provider.GetService<CarRentalDbContext>());

            services.AddScoped<IVehicleBrandService, VehicleBrandService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<IColorTypeService, ColorTypeService>();
            services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
