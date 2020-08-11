using System;
using System.Collections.Generic;
using System.Text;
using DevoxTestTask.DAL.Entities;
using DevoxTestTask.DAL.Extentions;
using Microsoft.EntityFrameworkCore;

namespace DevoxTestTask.DAL
{
    public class DevoxTestTaskDbContext: DbContext
    {
        public DevoxTestTaskDbContext(DbContextOptions<DevoxTestTaskDbContext> options)
            : base(options)
        { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
