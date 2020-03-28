using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultipleEnvsExample
{
    public class Startup
    {
         private readonly IHostEnvironment _env;
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            SharedConfigureServices(services);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            SharedConfigureServices(services);
        }
        public void SharedConfigureServices(IServiceCollection services){
            services.AddControllersWithViews();
        }

        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            SharedConfigure(app);
        }

        public void Configure(IApplicationBuilder app)
        {
           app.UseExceptionHandler("/Home/Error");
           app.UseHsts();
           SharedConfigure(app);
        }

        public void SharedConfigure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
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
