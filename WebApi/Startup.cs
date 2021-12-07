using Microsoft.EntityFrameworkCore;
using WebApi.Data;

public class Startup
{
    private  IConfiguration _config { get; }

    public Startup(IConfiguration config)
    {
        _config = config;
        
    }

    // Use this method to add services to the container.  
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DataContext>(provider => {
         provider.UseSqlite(_config.GetConnectionString("DefaultConnectionString"));
        });
        services.AddAuthorization();
        services.AddControllers();
    }
    // Use this method to configure the HTTP request pipeline.  
    public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }
        app.UseEndpoints(router => { router.MapControllers(); });
    }
}