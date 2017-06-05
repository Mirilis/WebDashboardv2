using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace WebDashboardv2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            if (System.Security.Principal.WindowsIdentity.GetCurrent().Name.Contains("MIRILISPC"))
            {
                services.AddDbContext<Model.ProcessCardContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalTestConnection")));
                services.AddSingleton<Model.IQualityAlertsModel, Model.QualityAlertsModelDesignTime>();
            }
            else
            {
                services.AddDbContext<Model.ProcessCardContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProcessCardConnection")));
                services.AddDbContext<Model.BrinellRecordsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BossRecordsConnection")));
                services.AddSingleton<Model.IQualityAlertsModel, Model.QualityAlertsModel>();
            }

            services.AddMvc();
            services.AddSingleton<Model.IProcessCardsModel, Model.ProcessCardsModel>();
            services.AddSingleton<Model.IProductsModel, Model.ProductsModel>();

            services.AddScoped<Model.IUserAccessModel, Model.UserAccessModel>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = Int32.MaxValue;
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardWindowsAuthentication = true;
                options.AutomaticAuthentication = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Model.ProcessCardContext context, Model.BrinellRecordsContext brinellContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}