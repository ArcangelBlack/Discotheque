using D.Models.Interfaces;
using DiscothequeW.Services;
using DiscothequeW.Services.Interaces;
using DiscothequeW.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using System.IO;

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

            //

            services.AddSingleton(provider => Configuration);
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDiscothequeService, DiscothequeService>();
            //services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMusicService, MusicService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPathProvider, PathProvider>();
            // Automapper Configuration
            //AutoMapperConfiguration.Configure();

            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory())),
                RequestPath = "/StaticFiles"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory())),
                RequestPath = "/StaticFiles"
            });

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs")),
            //    RequestPath = "/StaticFiles"
            //});

            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            //{
            //    FileProvider = new PhysicalFileProvider( Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs")),
            //    RequestPath = "/StaticFiles"
            //});

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
