using Microsoft.EntityFrameworkCore;

namespace UngeDrabanter.Models
{
    public class UngeDbContext : DbContext
    {
        public UngeDbContext(DbContextOptions<UngeDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        //public DbSet<EventUser> EventUsers { get; set; }

        public DbSet<Event> Events { get; set; }

        //public DbSet<Item> Items { get; set; }

        //public DbSet<ItemDetail> ItemDetails { get; set; }

        //public DbSet<Location> Locations { get; set; }

        //public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Sessions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
            .IsUnique();

            modelBuilder.Entity<Account>()
                .HasKey(a => new { a.ProviderAccountId, a.Provider });
        }
    }
}
