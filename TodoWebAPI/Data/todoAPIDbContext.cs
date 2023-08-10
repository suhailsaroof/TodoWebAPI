using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Model;

namespace TodoWebAPI.Data
{
    public class todoAPIDbContext : DbContext
    {
        public todoAPIDbContext(DbContextOptions<todoAPIDbContext> options) : base(options)
        {
        }

        public DbSet<TblUser> Tbluser { get; set; }
        public DbSet<Tbltodolist> Tbltodolist { get; set; }
        public DbSet<Tbltodotask> Tbltodotask { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}