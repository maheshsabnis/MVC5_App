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

        public async Task<Department> CreayeAsync(Department entity)
        {
            entity = context.Departments.Add(entity);
            // await --> means wait for the method to get execute
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsyc(int id)
        {
            var rec = await context.Departments.FindAsync(id);
            if (rec != null)
            {
                // delete the record
                context.Departments.Remove(rec);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Department>> GetAsync()
        {
            var res = await context.Departments.ToListAsync();
            return res;
        }

        public async Task<Department> GetAsync(int id)
        {
            var rec = await context.Departments.FindAsync(id);
            return rec;
        }

        public async Task<Department> UpdateAsync(int id, Department entity)
        {
            var rec = await context.Departments.FindAsync(id);
            if (rec != null)
            {
                // update the record
                rec.DeptName = entity.DeptName;
                rec.Location = entity.Location;
                await context.SaveChangesAsync();
                return rec; // updated value
            }
            return entity; // non-updated value
        }
    }
}