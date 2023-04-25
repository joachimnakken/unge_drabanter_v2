using Microsoft.EntityFrameworkCore;

namespace UngeDrabanter.Models
{
    public class UngeDbContext : DbContext
    {
        public UngeDbContext(DbContextOptions<UngeDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }

        //public DbSet<EventUser> EventUsers { get; set; }

        public DbSet<Event> Events { get; set; }

        //public DbSet<Item> Items { get; set; }

        //public DbSet<ItemDetail> ItemDetails { get; set; }

        //public DbSet<Location> Locations { get; set; }

        //public DbSet<Rating> Ratings { get; set; }

    }
}
