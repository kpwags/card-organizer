using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardOrganizer.Infrastructure.Database;

public class Role : IdentityRole<int> {}

public class ApplicationDbContext : IdentityDbContext<UserAccountDto, IdentityRole<int>, int>
{
    public DbSet<BrandDto> Brands { get; set; }
    
    public DbSet<BaseballCard> BaseballCards { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        builder.HasDefaultSchema("application");
        
        #region "Brand"
        builder.Entity<BrandDto>()
            .ToTable("Brand", schema: "card");

        builder.Entity<BrandDto>()
            .HasKey(b => b.BrandId)
            .HasName("PK_Card_Brand");
        
        builder.Entity<BrandDto>()
            .Property(b => b.CardTypeId)
            .IsRequired();
        
        builder.Entity<BrandDto>()
            .Property(b => b.Name)
            .HasMaxLength(150)
            .IsRequired();
        #endregion "Brand"
        
        #region "BaseballCard"
        builder.Entity<BaseballCardDto>()
            .ToTable("BaseballCard", schema: "card");

        builder.Entity<BaseballCardDto>()
            .HasKey(b => b.BaseballCardId)
            .HasName("PK_Card_BaseballCard");
        
        builder.Entity<BaseballCardDto>()
            .Property(b => b.Year)
            .IsRequired();
        
        builder.Entity<BaseballCardDto>()
            .Property(b => b.CardNumber)
            .IsRequired();
        
        builder.Entity<BaseballCardDto>()
            .Property(b => b.PlayerName)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Entity<BaseballCardDto>()
            .Property(b => b.PlayerPosition)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Entity<BaseballCardDto>()
            .Property(b => b.Team)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Entity<BaseballCardDto>()
            .Property(b => b.Flags)
            .HasMaxLength(100)
            .IsRequired();

        builder.Entity<BaseballCardDto>()
            .HasOne(bc => bc.Brand)
            .WithMany(b => b.BaseballCards);
        
        builder.Entity<BaseballCardDto>()
            .HasOne(bc => bc.UserAccount)
            .WithMany(b => b.BaseballCards);
        #endregion "BaseballCard"
    }
}