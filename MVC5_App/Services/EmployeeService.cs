using MVC5_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC5_App.Services
{
    public class EmployeeService : IService<Employee, int>
    {
        private readonly EmployeeEDMX context;
        /// <summary>
        /// Inject an instance of EmployeeEDMX
        /// </summary>
        public EmployeeService(EmployeeEDMX context)
        {
            this.context = context;
        }

        public  Employee CreayeAsync(Employee entity)
        {
            entity = context.Employees.Add(entity);
            // await --> means wait for the method to get execute
             context.SaveChanges();
            return entity;
        }

        public  bool DeleteAsyc(int id)
        {
            var rec =   context.Employees.Find(id);
            if (rec != null)
            {
                // delete the record
                context.Employees.Remove(rec);
                 context.SaveChanges();
                return true;
            }
            return false;
        }

        public    IEnumerable<Employee> GetAsync()
        {
            var res =  context.Employees.ToList();
            return res;
        }

        public  Employee GetAsync(int id)
        {
            var rec =  context.Employees.Find(id);
            return rec;
        }

        public Employee UpdateAsync(int id, Employee entity)
        {
            var rec =context.Employees.Find(id);
            if (rec != null)
            {
                // update the record
                rec.EmpName = entity.EmpName;
                rec.Designation = entity.Designation;
                rec.Salary = entity.Salary;
                rec.DeptNo = entity.DeptNo;
                 context.SaveChanges();
                return rec; // updated value
            }
            return entity; // non-updated value
        }
    }
}