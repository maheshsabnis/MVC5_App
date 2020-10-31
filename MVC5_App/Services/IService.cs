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
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreayeAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<bool> DeleteAsyc(TPk id);
    }
}
