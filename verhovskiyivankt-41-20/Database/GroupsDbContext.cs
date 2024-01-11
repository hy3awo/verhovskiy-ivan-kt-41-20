using Microsoft.EntityFrameworkCore;
using VerhovskiyIvanKT_41_20.Database.Configuration;
using VerhovskiyIvanKT_41_20.Models;

namespace VerhovskiyIvanKT_41_20.Database
{
    public class GroupsDbContext : DbContext
    {
        
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }

        public GroupsDbContext(DbContextOptions<GroupsDbContext> options) : base(options)
        {

        }
    }
    
    
}
