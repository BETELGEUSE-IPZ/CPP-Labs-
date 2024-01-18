using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data;


public class Context(
    DbContextOptions<Context> options
) : IdentityDbContext<User>(options)
{ }