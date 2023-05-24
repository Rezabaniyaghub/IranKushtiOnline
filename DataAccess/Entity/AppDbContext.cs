using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).HasMaxLength(50).IsRequired();
                x.Property(p => p.Capacity).HasMaxLength(50);
                x.Property(p => p.PhoneNumber).HasMaxLength(50);
                x.Property(p => p.Address).IsRequired();
                x.HasMany(p => p.ClassRooms).WithOne(p => p.School);
                x.Property(p => p.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()").HasMaxLength(15);
                x.HasIndex(p => p.Name);
                x.HasIndex(p => p.PhoneNumber);
            });
            modelBuilder.Entity<ClassRoom>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                x.Property(p => p.LastName).HasMaxLength(50).IsRequired();
                x.Property(p => p.Gender).IsRequired();
                x.Property(p => p.BirhDate).HasColumnType("datetime").HasDefaultValueSql("getdate()").HasMaxLength(15).IsRequired();
                x.Property(p => p.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()").HasMaxLength(15);
                x.Property(p => p.Country).HasMaxLength(50);
                x.Property(p => p.PhoneNumber).HasMaxLength(15);
                x.Property(p => p.AgeRange).HasMaxLength(50).IsRequired();
                x.Property(p => p.SchoolId).IsRequired();
                x.HasOne(p => p.School).WithMany(p => p.ClassRooms).
                HasForeignKey(k => k.SchoolId);
                x.HasIndex(p => p.LastName);
                x.HasIndex(p => p.SchoolId);
            });
        }
        public DbSet<School> Schools { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
    }
}
