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
        public DbSet<Users> Users { get; set; }
    }
}
