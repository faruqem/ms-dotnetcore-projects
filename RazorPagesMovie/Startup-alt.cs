using RazorPagesMovie.Data;
using Microsoft.EntityFrameworkCore;
/*
namespace RazorPagesMovie{
    public class Startup
    {
        //The following code shows how to inject IWebHostEnvironment into Startup. 
        //IWebHostEnvironment is injected so ConfigureServices can use SQLite in development 
        //and SQL Server in production.
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<RazorPagesMovieContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("MovieContext")));
            }
            else
            {
                services.AddDbContext<RazorPagesMovieContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MovieContext")));
            }

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
*/