using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repositories
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Get(int Id);
        Task<T> Add(T entity);
        void Edit(T entity);
        T Delete(T entity);
        IEnumerable<T> GetByConditionWithInclude(Expression<Func<T, bool>> expression, List<string> includes);
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
