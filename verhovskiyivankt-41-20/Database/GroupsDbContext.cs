using Microsoft.EntityFrameworkCore;
using VerhovskiyIvanKT_41_20.Models;

namespace VerhovskiyIvanKT_41_20.Database
{
    public class GroupsDbContext : DbContext
    {
        public GroupsDbContext(DbContextOptions<GroupsDbContext> options) : base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
    
    
}
