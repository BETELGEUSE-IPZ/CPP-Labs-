using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.Authority = "http://localhost:5001";

                options.ClientId = "MainWebApp";
                options.ClientSecret = "MainWebApp";
                options.ResponseType = "code";
                options.Scope.Add("extended_profile");
                options.ClaimActions.MapUniqueJsonKey("full_name", "full_name");
                options.ClaimActions.MapUniqueJsonKey("phone_number", "phone_number");

                options.GetClaimsFromUserInfoEndpoint = true;
                options.RequireHttpsMetadata = false;
                options.SaveTokens = true;
            });

        builder.Services.AddRazorPages();


        var app = builder.Build();

        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();

        app.Run();
    }
}