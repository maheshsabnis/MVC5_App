using MVC5_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC5_App.Services
{
    public class DepartmentService : IService<Department, int>
    {
        private readonly EmployeeEDMX context;
        /// <summary>
        /// Inject an instance of EmployeeEDMX
        /// </summary>
        public DepartmentService(EmployeeEDMX context)
        {
            this.context = context;
        }

        public  Department CreayeAsync(Department entity)
        {
            entity = context.Departments.Add(entity);
            // await --> means wait for the method to get execute
             context.SaveChanges();
            return entity;
        }

        public  bool DeleteAsyc(int id)
        {
            var rec =   context.Departments.Find(id);
            if (rec != null)
            {
                // delete the record
                context.Departments.Remove(rec);
                 context.SaveChanges();
                return true;
            }
            return false;
        }

        public    IEnumerable<Department> GetAsync()
        {
            var res =  context.Departments.ToList();
            return res;
        }

        public  Department GetAsync(int id)
        {
            var rec =  context.Departments.Find(id);
            return rec;
        }

        public Department UpdateAsync(int id, Department entity)
        {
            var rec =context.Departments.Find(id);
            if (rec != null)
            {
                // update the record
                rec.DeptName = entity.DeptName;
                rec.Location = entity.Location;
                 context.SaveChanges();
                return rec; // updated value
            }
            return entity; // non-updated value
        }
    }
}