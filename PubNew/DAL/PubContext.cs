using Microsoft.AspNet.Identity.EntityFramework;
using PubNew.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PubNew.DAL
{
    public class PubContext : IdentityDbContext<User>
    {

        public PubContext() : base("PubContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PubContext, Migrations.Configuration>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<IdentityUserRole> UserRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserClaim>().ToTable("IdentityUserClaim");

            // EF won't let us swap out IdentityUserRole for ApplicationUserRole here:
            modelBuilder.Entity<User>().HasMany<IdentityUserRole>((User u) => u.Roles);

            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            // Leave this alone:
            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey
                        = l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            // Add this, so that IdentityRole can share a table with UserRole:
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");



            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            modelBuilder.Entity<User>().ToTable("User");

            //base.OnModelCreating(modelBuilder);
        }

        public static PubContext Create()
        {
            return new PubContext();
        }

    }
}