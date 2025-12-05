using EfCore1.models;
using EfCore1.ValidationRules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EfCore1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> Groups { get; set; }
        public DbSet<UserInterestGroup> UserGroup { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserEFCore;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<Role>()
                .HasMany(g => g.Users)
                .WithOne(s => s.Role)
                .HasForeignKey(s => s.RoleId);

             modelBuilder.Entity<UserInterestGroup>()
                .HasKey(cs => new { cs.UserId, cs.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
               .HasOne(ug => ug.User)
               .WithMany(u => u.UserGroup) 
               .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserInterestGroup>()
                 .HasOne(cs => cs.InterestGroup)
                 .WithMany(c => c.UserGroup)
                 .HasForeignKey(cs => cs.InterestGroupId);

        }
    }
}
