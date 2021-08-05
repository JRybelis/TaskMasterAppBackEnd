using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskmasterCore.Models;

namespace TaskMasterApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
            if (!Tasks.Any())
            {
                Tasks.Add(new TaskItem()
                {
                    Id = 1,
                    Text = "Drink water",
                    Day = "Thursday",
                    Reminder = true
                });
                Tasks.Add(new TaskItem()
                {
                    Id = 2,
                    Text = "Put away your clothes",
                    Day = "Thursday",
                    Reminder = false
                });
                SaveChanges();
            }
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
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<TaskItem>()
                .Property(ti => ti.Text)
                .HasMaxLength(511)
                .IsRequired();
        }
    }
}
