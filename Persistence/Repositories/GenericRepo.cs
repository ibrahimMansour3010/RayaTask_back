using Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly RayaTaskDBContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepo(RayaTaskDBContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var result = await _entity.AddAsync(entity);
            return result.Entity;
        }

        public T Delete(T entity)
        {
            var result = _entity.Remove(entity);
            return result.Entity;
        }

        public void Edit(T entity)
        {
            _entity.Update(entity);
        }

        public async Task<T> Get(int Id)
        {
            var result =  await _entity.FindAsync(Id);
            return result;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public IEnumerable<T> GetByConditionWithInclude(Expression<Func<T, bool>> expression, List<string> includes)
        {
            var result = _entity.Where(expression);
            includes.ToList().ForEach(a =>
            {
                result = result.Include(a);
            });
            return result;
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _entity.Where(expression);
        }
    }
}
