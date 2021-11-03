using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Contracts
{
    public interface IMainService<T> where T:class
    {
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        bool AddRange(ICollection<T> entities);
        Task<bool> AddRangeAsync(ICollection<T> entities);

        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);

        bool UpdateRange(ICollection<T> entities);
        Task<bool> UpdateRangeAsync(ICollection<T> entities);
        bool AddOrUpdate(Expression<Func<T, object>> identifier, ICollection<T> entityCollections);

        bool Remove(T entity, bool isShiftDeleted = false);
        bool RemoveRange(ICollection<T> entities, bool isShiftDeleted = false);
    }
}
