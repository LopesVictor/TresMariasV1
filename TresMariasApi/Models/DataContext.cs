using Microsoft.EntityFrameworkCore;
using TresMariasWebApp.Models;

namespace TresMariasWebApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Route> Route { get; set; }

        public DbSet<Chat> Chat { get; set; }

        public DbSet<TresMariasWebApp.Models.Message> Message { get; set; }
    }
}
