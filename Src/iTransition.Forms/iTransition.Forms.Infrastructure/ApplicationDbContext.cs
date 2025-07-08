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
            builder.Entity<Tag>().HasData
            (
                new Tag
                {
                    Id = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                    Name = "General",
                },
                new Tag
                {
                    Id = Guid.Parse("24A44820-CFF8-4509-AA16-A1F4C5BB0BD5"),
                    Name = "Quiz",
                },
                new Tag
                {
                    Id = Guid.Parse("4DB86802-9AEA-4E7E-801A-B05A2463BE39"),
                    Name = "Developer",
                },
                new Tag
                {
                    Id = Guid.Parse("0FADBF4C-F8CF-4937-86A2-0CA33FEB33F9"),
                    Name = "Survey"
                },
                new Tag
                {
                    Id = Guid.Parse("0EF5E8C0-EA9E-458D-B82F-9BD361F6EAE5"),
                    Name = "Other"
                }
            );

            builder.Entity<TemplateTag>()
              .HasKey(x => new { x.TemplateId, x.TagId });

            builder.Entity<TemplateTag>()
                .HasOne(x => x.Template)
                .WithMany(y => y.TemplateTags)
                .HasForeignKey(z => z.TemplateId);

            builder.Entity<TemplateTag>()
               .HasOne(x => x.Tag)
               .WithMany(y => y.TemplateTags)
               .HasForeignKey(z => z.TagId);

            builder.Entity<Template>()
                .HasOne(x => x.Topic)
                .WithMany(c => c.Templates)
                .HasForeignKey(y => y.TopicId);


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

           


            builder.Entity<ApplicationUser>()
                .HasData
                (
                    new ApplicationUser
                    {
                        Id = Guid.Parse("41c1f025-c383-44bb-99d3-64a93dc932f9"),
                        UserName = "admin",
                        NormalizedUserName = "ADMIN",
                        PasswordHash = "AQAAAAIAAYagAAAAEJvlP7iT7x94GkCsdqJRk0qGdGTywCXDjEP57/J0lodU+Z2mFSPoU2Trb20dkgYRQA==",
                        FullName = "Admin",
                        IsBlocked = false,
                        SecurityStamp = "354FC657-CA80-458A-8719-ED65269683AD",
                        ConcurrencyStamp = "2B157DA1-B4A6-4CAD-8CCE-F5BD6CB1B9AB"
                    }
                );
            builder.Entity<ApplicationRole>()
                .HasData
                (
                    new ApplicationRole
                    {
                        Id = Guid.Parse("a83f3b24-cb63-4ec4-bc80-ef4eaaba047d"),
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = "85B8C5A1-9792-4326-9AE8-06376CCD638C"
                    }
                );
            builder.Entity<ApplicationUserRole>()
                .HasData
                (
                    new ApplicationUserRole
                    {
                        RoleId = Guid.Parse("a83f3b24-cb63-4ec4-bc80-ef4eaaba047d"),
                        UserId = Guid.Parse("41c1f025-c383-44bb-99d3-64a93dc932f9")
                    }
                );

            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(builder);
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateTag> TemplateTags { get; set; }
    }
}