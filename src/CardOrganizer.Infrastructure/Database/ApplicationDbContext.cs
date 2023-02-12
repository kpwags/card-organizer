using CardOrganizer.Domain.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardOrganizer.Infrastructure.Database;

public class Role : IdentityRole<int> {}

public class ApplicationDbContext : IdentityDbContext<UserAccountDto, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        builder.HasDefaultSchema("application");
    }
}