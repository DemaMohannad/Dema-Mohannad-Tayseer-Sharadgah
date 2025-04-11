using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biding.Domain.Models;

namespace Biding.Infrastructure
{
    public class BidingDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Tender> Tenders { get; set; }

        public virtual DbSet<Bid> Bids { get; set; }

        public virtual DbSet<Evaluation> Evaluations { get; set; }

        public virtual DbSet<TenderType> Typy { get; set; }

        public virtual DbSet<TenderCategory> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-KM4D46T; database=BidingManagement ;user id= Dema; password=sky@25;TrustServerCertificate=True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserName).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Password).IsRequired();
            });
            modelBuilder.Entity<Tender>(entity =>
            {
                entity.HasKey(e => e.TenderID);
                entity.Property(e => e.TenderTitle).IsRequired();
                entity.Property(e => e.TenderReferenceNumber).IsRequired();
                entity.Property(e => e.IssueDate).IsRequired();
                entity.Property(e => e.ClosingDate).IsRequired();
                entity.Property(e => e.TypeID).IsRequired();
                entity.Property(e => e.TenderType).IsRequired();
                entity.Property(e => e.CategoryID).IsRequired();
                entity.Property(e => e.TenderCategory).IsRequired();
                entity.HasIndex(e => e.ContactEmail).IsUnique();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.document).IsRequired();
            });
            modelBuilder.Entity<Bid>(entity =>
            {
                entity.HasKey(e => e.BidID);
                entity.Property(e => e.TenderID).IsRequired();
                entity.Property(e => e.CompanyName).IsRequired();
                entity.Property(e => e.TechnicalProposalPath).IsRequired();
                entity.Property(e => e.FinancialProposalPath).IsRequired();
                entity.Property(e => e.SubmittedAt).IsRequired();
                entity.Property(e => e.document).IsRequired();
            });
            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.BidID).IsRequired();
                entity.Property(e => e.score).IsRequired();
                entity.Property(e => e.Comments).IsRequired();

            });
            modelBuilder.Entity<TenderType>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Type).IsRequired();

            });
            modelBuilder.Entity<TenderCategory>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CategoryName).IsRequired();

            });

            modelBuilder.Entity<Tender>()
                .HasOne<User>(d => d.IssuedBy)
                .WithMany(e => e.Tenders)
                .HasForeignKey(e => e.UserID);
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bid>()
               .HasOne<Tender>(d => d.Tenders)
               .WithMany(e => e.Bids)
               .HasForeignKey(e => e.TenderID);

            modelBuilder.Entity<Evaluation>()
               .HasOne<Tender>(d => d.Bid)
               .WithMany(e => e.Evaluation)
               .HasForeignKey(e => e.BidID);

            modelBuilder.Entity<Tender>()
               .HasOne<TenderType>(t => t.Type)
               .WithMany(e => e.Tenders)
               .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<Tender>()
               .HasOne<TenderCategory>(t => t.Category)
               .WithMany(e => e.Tenders)
               .HasForeignKey(e => e.CategoryID);

        }
    }
}
