namespace MVC5_App.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeEDMX : DbContext
    {
        public EmployeeEDMX()
            : base("name=CompanyEDMX")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Designation)
                .IsUnicode(false);
        }
    }
}
