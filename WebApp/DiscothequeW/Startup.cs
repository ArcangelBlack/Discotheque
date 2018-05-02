using D.Models;
using D.Models.Interfaces;
using D.Models.Models;
using D.Models.Repositories;
using DiscothequeW.Services;
using DiscothequeW.Services.Interaces;
using DiscothequeW.Services.Interfaces;
using DiscothequeW.ViewModels.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace DiscothequeW
{
    public class Startup
    {
        bool useInMemoryProvider = false;

        public Startup(IConfiguration configuration)
        {
            //var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            //string sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            //try
            //{
            //    useInMemoryProvider = bool.Parse(Configuration["AppSettings:InMemoryProvider"]);
            //}
            //catch { }

            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    switch (useInMemoryProvider)
            //    {
            //        case true:
            //            options.UseInMemoryDatabase();
            //            break;
            //        default:
            //            //options.UseSqlServer(sqlConnectionString, b => b.MigrationsAssembly("DiscothequeW"));
            //            options.UseSqlServer(@"Data Source=ITE-CCUMPA\SQLEXPRESS; Catalog=DiscothequeDb; Integrated Security=True;", b => b.UseRowNumberForPaging());
            //            break;
            //    }
            //});

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IDiscothequeService, DiscothequeService>();
            //services.AddScoped<ICompanyService, CompanyService>();

            services.AddSingleton(provider => Configuration);
            services.AddScoped<IEmployeeService, EmployeeService>();

            // Automapper Configuration
            //AutoMapperConfiguration.Configure();

            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
