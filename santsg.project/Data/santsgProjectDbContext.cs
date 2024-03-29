using Microsoft.EntityFrameworkCore;
using santsg.project.Entities;

namespace santsg.project.Data
{
    public class santsgProjectDbContext : DbContext
    {
        public santsgProjectDbContext(DbContextOptions options) : base(options)
        {
            //options ile bağlantı dizesi alınmış olacak
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
