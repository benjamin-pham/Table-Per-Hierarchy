using Microsoft.EntityFrameworkCore;
using TPH.Entities;

namespace TPH
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        public DbSet<User> User { get; set; }
    }
}
