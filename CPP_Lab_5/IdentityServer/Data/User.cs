using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data;


public class User : IdentityUser
{
    public required string FullName { get; set; }
}