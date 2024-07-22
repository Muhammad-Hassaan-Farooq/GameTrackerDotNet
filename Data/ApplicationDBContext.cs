
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext:IdentityDbContext<AppUser>{

    public DbSet<Game> Games { get; set; }
    public DbSet<Note> Notes { get; set; }
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Game>()
            .HasOne(g => g.User)
            .WithMany(u => u.Games)
            .HasForeignKey(g => g.UserID)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Entity<Note>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notes)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Note>()
            .HasOne(n => n.Game)
            .WithMany(g => g.Notes)
            .HasForeignKey(n => n.GameId)
            .OnDelete(DeleteBehavior.Cascade);

            List<AppRole> roles = new List<AppRole>
            {
                new AppRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<AppRole>().HasData(roles);
    }

}