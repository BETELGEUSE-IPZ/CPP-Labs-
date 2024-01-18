using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer;


public class ProfileService(UserManager<User> userManager) : IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        context.IssuedClaims.AddRange(context.Subject.Claims);
        return Task.CompletedTask;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var user = await userManager.GetUserAsync(context.Subject);
        context.IsActive = user is not null;
    }
}