using Microsoft.EntityFrameworkCore;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MyHarvestApi.Entity.Model.Task;

namespace MyHarvestApi.Entity.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Replies)
                .WithOne(e => e.Boss)
                .HasForeignKey(e => e.IdBoss);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<StatusOfTask> StatusOfTasks { get; set; }
        public DbSet<UserInformation> UsersInformation { get; set; }
        public DbSet<PointOnTheMap> PointsOnTheMap { get; set; }
        public DbSet<Waypoint> Waypoints { get; set; }
    }
}