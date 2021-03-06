namespace MVC5_App.Models
{
    using MVC5_App.CustomValidators;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpNo { get; set; }

        [Required]
        [StringLength(100)]
        public string EmpName { get; set; }

        [Required]
        [StringLength(100)]
        public string Designation { get; set; }
        [NumericValidator(ErrorMessage ="Salary Cannot be -ve")]
        [Remote("SalaryAsyncValidator", "Employee")]
        public int Salary { get; set; }

        public int DeptNo { get; set; }

        public virtual Department Department { get; set; }
    }
}
