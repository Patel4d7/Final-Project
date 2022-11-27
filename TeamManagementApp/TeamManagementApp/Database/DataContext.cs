using Microsoft.EntityFrameworkCore;
using TeamManagementApp.Models;

namespace TeamManagementApp.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<TeamInfo> TeamInfos { get; set; }
    }
}
