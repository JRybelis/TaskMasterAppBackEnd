using Microsoft.EntityFrameworkCore;
using TaskmasterCore.Models;

namespace TaskMasterApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureModelPrimaryKeys(modelBuilder);
            ConfigureModelProperties(modelBuilder);
        }

        private void ConfigureModelPrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasKey(ti => ti.Id);
        }
        private void ConfigureModelProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .Property(ti => ti.Day)
                .HasMaxLength(9)
                .IsRequired();

            modelBuilder.Entity<TaskItem>()
                .Property(ti => ti.Text)
                .HasMaxLength(511)
                .IsRequired();
        }
    }
}
