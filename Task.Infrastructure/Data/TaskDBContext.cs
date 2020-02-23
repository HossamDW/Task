using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Core.Entities;

namespace Task.Infrastructure.Data
{
    public class TaskDBContext : DbContext
    {
        public string ConnectionString { get; set; }

        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {

        }

        public DbSet<Area> Areas { set; get; }
        public DbSet<City> Cities { set; get; }
        public DbSet<District> Districts { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
