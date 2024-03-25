using Microsoft.EntityFrameworkCore;

namespace ApiVilla.Models
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       
        {
            
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
