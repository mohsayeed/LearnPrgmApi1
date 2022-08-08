using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearnPrgmApi.Models
{
    public partial class learnprgmContext : DbContext
    {
        public learnprgmContext()
        {
        }

        public learnprgmContext(DbContextOptions<learnprgmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentDetail> StudentDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.ToTable("studentDetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
