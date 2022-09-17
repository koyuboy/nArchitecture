using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        //Core Entities
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<GithubAccount> GithubAccounts { get; set; }


        //Entities
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Core Entities

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.FirstName).HasColumnName("FirstName");
                u.Property(u => u.LastName).HasColumnName("LastName");
                u.Property(u => u.Email).HasColumnName("Email");
                u.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                u.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(u => u.Status).HasColumnName("Status");
                u.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                u.HasMany(u => u.UserOperationClaims);
                u.HasMany(u => u.RefreshTokens);
            });
            User[] userEntitySeeds =
            {
                new(1,"Ahmet","Demir","ahmet@demir.com",Encoding.ASCII.GetBytes("ahmet"), Encoding.ASCII.GetBytes("demir"),false, AuthenticatorType.None),
                new(2, "Huzeyfe","Demir","huzeyfe@demir.com",Encoding.ASCII.GetBytes("huzeyfe"), Encoding.ASCII.GetBytes("demir"),false, AuthenticatorType.None )
            };
            modelBuilder.Entity<User>().HasData(userEntitySeeds);



            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

            });
            OperationClaim[] operationClaimEntitySeeds = { new(1, "user"), new(2, "admin") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);



            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.OperationClaimId).HasColumnName("OperationClaimId");
                a.Property(a => a.UserId).HasColumnName("UserId");
                a.HasOne(a => a.OperationClaim);
                a.HasOne(a => a.User);

            });
            UserOperationClaim[] userOperationClaimEntitySeeds = { new(1, 1, 2) };
            modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaimEntitySeeds);

            //Entities

            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });
            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });
            Technology[] technologyEntitySeeds = { new(1, 2, "Spring"), new(2, 1, "WPF") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);


            modelBuilder.Entity<Member>(p =>
            {
                p.ToTable("Members");
                p.HasMany(p => p.GithubAccounts);
            });


            modelBuilder.Entity<GithubAccount>(p =>
            {
                p.ToTable("GithubAccounts").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.MemberId).HasColumnName("MemberId");
                p.Property(p => p.GithubLink).HasColumnName("GithubLink");
                p.HasOne(p => p.Member);
            });

        }
    }
}
