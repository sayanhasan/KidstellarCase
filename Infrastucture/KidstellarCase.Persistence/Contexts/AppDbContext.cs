using KidstellarCase.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseMySql(Configuration.ConnectionString, serverVersion: ServerVersion.AutoDetect(Configuration.ConnectionString), mySqlOptions => mySqlOptions.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
