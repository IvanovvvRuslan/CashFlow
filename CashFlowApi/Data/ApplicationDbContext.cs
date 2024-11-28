using CashFlowApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Hosting;

namespace CashFlowApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
                        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Companies)
                .WithMany(c => c.Users)
                .UsingEntity<UserCompany>(
                    j => j.HasOne(uc => uc.Company).WithMany().HasForeignKey(uc => uc.CompanyId).OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne(uc => uc.User).WithMany().HasForeignKey(uc => uc.UserId).OnDelete(DeleteBehavior.Restrict));

           modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRole>(
                    j => j.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId).OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId).OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Phones)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<User>()
               .HasMany(u => u.ContactCompanies)
               .WithOne(cc => cc.ContactUser)
               .HasForeignKey(cc => cc.ContactUserId);

            modelBuilder.Entity<User>()
               .HasMany(u => u.CompaniesOwner)
               .WithOne(co => co.Owner)
               .HasForeignKey(cc => cc.OwnerId);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "AdminTestUser",
                    Password = "admin",
                    Email = "admintest@company.com",
                    Description = "Admin test account",
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "AdminTestRole",
                    Description = "Admin test role",
                });

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "TestCompany",
                    OwnerId = 1,
                    ContactUserId = 1,
                    Email = "testcompany@company.com",
                    Address = "testaddress",
                    Description = "Test Cpmpany"
                });

        }
    }
}
