using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Entities
{
    public partial class User
    {
        public class DataBaseContext : DbContext
        {
            public DataBaseContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<User> Users { get; set; }
        }


    }
}
