using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTransition.Forms.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
                                        <ApplicationUser, ApplicationRole, Guid,
                                        ApplicationUserClaim, ApplicationUserRole,
                                        ApplicationUserLogin, ApplicationRoleClaim,
                                        ApplicationUserToken>
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Topic>().HasData
            (
                new Topic
                {
                    Id = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                    Name = "Education",
                },
                new Topic
                {
                    Id = Guid.Parse("24A44820-CFF8-4509-AA16-A1F4C5BB0BD5"),
                    Name = "Quiz",
                },
                new Topic
                {
                    Id = Guid.Parse("4DB86802-9AEA-4E7E-801A-B05A2463BE39"),
                    Name = "Poll",
                },
                new Topic
                {
                    Id = Guid.Parse("0FADBF4C-F8CF-4937-86A2-0CA33FEB33F9"),
                    Name = "Survey"
                },
                new Topic
                {
                    Id = Guid.Parse("0EF5E8C0-EA9E-458D-B82F-9BD361F6EAE5"),
                    Name = "Other"
                }
            );
        }
        public DbSet<Topic> Topics { get; set; }
    }
}