using IdentityServer;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContextPool<Context>(optionsBuilder =>
        {
            optionsBuilder.UseSqlite("DataSource=" + Path.Combine(
                builder.Environment.ContentRootPath,
                "Db"
            ));
        });

        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<Context>();
        builder.Services.AddIdentityServer()
            .AddInMemoryIdentityResources(Configuration.IdentityResources)
            .AddInMemoryClients(Configuration.Clients)
            .AddAspNetIdentity<User>()
            .AddProfileService<ProfileService>();

        builder.Services.AddRazorPages();


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            using var context = scope.ServiceProvider.GetRequiredService<Context>();
            context.Database.EnsureCreated();
        }

        app.UseStaticFiles();
        app.UseCookiePolicy(new CookiePolicyOptions
        {
            Secure = CookieSecurePolicy.Always
        });
        app.UseIdentityServer();
        app.UseAuthorization();
        app.MapRazorPages();

        app.Run();
    }
}