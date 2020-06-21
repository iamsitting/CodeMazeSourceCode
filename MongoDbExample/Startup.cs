using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDbExample.Models;
using MongoDbExample.Services;

namespace MongoDbExample
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
            services.Configure<SchoolDatabaseSettings>(
                Configuration.GetSection(nameof(SchoolDatabaseSettings)));

            services.AddSingleton<ISchoolDatabaseSettings>(provider =>
                provider.GetRequiredService<IOptions<SchoolDatabaseSettings>>().Value);

            services.AddSingleton<StudentService>();
            services.AddSingleton<CourseService>();
            services.AddGrpc();
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseGrpcWeb();
            // Add after existing UseGrpcWeb
            app.Use((c, next) =>
            {
                if (c.Request.ContentType == "application/grpc-web-text")
                {
                    var current = c.Features.Get<IHttpResponseFeature>();
                    c.Features.Set<IHttpResponseFeature>(new HttpSysWorkaroundHttpResponseFeature(current));
                }
                return next();
            });
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<Student2Service>().EnableGrpcWeb().RequireCors("AllowAll");
                // endpoints.MapControllers();
            });
        }
    }
}
