using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_App.Services
{
    /// <summary>
    /// INterface with COnstraints
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The Entity Class on which CRUD operations are performed
    /// e.g. Department, Employee</typeparam>
    /// <typeparam name="TPk">
    ///   The Primary Key value, 'in' means the primary key value will always be input 
    ///   parameter to method
    /// </typeparam>
    public interface IService<TEntity, in TPk> where TEntity: class
    {
        IEnumerable<TEntity> GetAsync();
         TEntity GetAsync(TPk id);
         TEntity CreayeAsync(TEntity entity);
         TEntity UpdateAsync(TPk id, TEntity entity);
         bool DeleteAsyc(TPk id);
    }
}
