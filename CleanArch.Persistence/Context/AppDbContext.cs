using Microsoft.EntityFrameworkCore;
using CleanArch.Domain.Entities;


namespace CleanArch.Persistence.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
