using LandmarkRemark.Domain;
using Microsoft.EntityFrameworkCore;

namespace LandmarkRemark.Context
{
    public class LandmarkRemarkContext:DbContext
    {
        public LandmarkRemarkContext(DbContextOptions<LandmarkRemarkContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
