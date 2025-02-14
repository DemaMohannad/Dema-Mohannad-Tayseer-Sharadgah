using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace first_project.Entities
{
    public class EFCoreDbContext :DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-KM4D46T; database=EmployeeManagement ;user id= Dema; password=sky@25;TrustServerCertificate=True; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentID);
                entity.Property(e => e.DepartmentID).ValueGeneratedOnAdd();
                entity.Property(e => e.DepartmentName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionID);
                entity.Property(e => e.PositionID).ValueGeneratedOnAdd();
                entity.Property(e => e.PositionName).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber);
                entity.Property(e => e.EmployeeNumber).IsRequired().HasMaxLength(6);
                entity.Property(e => e.EmployeeName).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Gender).HasMaxLength(1);
                entity.Property(e => e.Reportedtoempnum).HasMaxLength(6);
                entity.Property(e => e.Vacdaysleft).IsRequired().HasDefaultValue(24);
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");

            });

            modelBuilder.Entity<VacationType>(entity =>
            {
                entity.HasKey(e => e.VacationTypeCode);
                entity.Property(e => e.VacationTypeCode).IsRequired().HasMaxLength(1);
                entity.Property(e => e.VacationTypeName).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<RequestState>(entity =>
            {
                entity.HasKey(e => e.StateID);
                entity.Property(e => e.StateName).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<VacationRequest>(entity =>
            {
                entity.HasKey(e => e.RequestID);
                entity.Property(e => e.RequestID).ValueGeneratedOnAdd();
                entity.Property(e => e.ReqSubmissionDate).IsRequired();
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
                entity.Property(e => e.VacTypeCode).HasMaxLength(1);
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.TotalVacDaye).IsRequired();
                entity.Property(e => e.RequestStateID).IsRequired();
            });

            modelBuilder.Entity<Employee>()
                .HasOne<Department>(d => d.Department)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.DepID);

            modelBuilder.Entity<Employee>()
               .HasOne<Position>(p => p.Position)
               .WithMany(e => e.Employees)
               .HasForeignKey(e => e.PosID);

            modelBuilder.Entity<VacationRequest>()
               .HasOne<Employee>(e => e.Employee)
               .WithMany(e => e.VacationRequests)
               .HasForeignKey(e => e.EmpNumber);

            modelBuilder.Entity<VacationRequest>()
              .HasOne<VacationType>(e => e.VacationType)
              .WithMany(e => e.VacationRequests);

            modelBuilder.Entity<VacationRequest>()
              .HasOne<RequestState>(e => e.RequestState)
              .WithMany(e => e.VacationRequests);
        }

    }
}
