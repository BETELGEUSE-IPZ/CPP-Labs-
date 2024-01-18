using lab6.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Okta.AspNetCore;
using System.Collections.Generic;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:44379/");

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
})
.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOktaMvc(new OktaMvcOptions
{
    OktaDomain = "https://dev-35903550.okta.com",
    AuthorizationServerId = "default",
    ClientId = "0oacuj8vtdfLMFSMH5d7",
    ClientSecret = "OUXC041o24n1CcJisF6iSND_l45Q0NxLmcYiXpqFo_Y2EvnQJ82fcwrJ79Ls-VaQ",
    Scope = new List<string> { "openid", "profile", "email", "phone" },
});
builder.Services.AddSingleton<ApiDataSource>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
