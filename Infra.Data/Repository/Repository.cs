using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            await SaveChanges();
        }

        public async Task Criar(T entity)
        {
            _context.Set<T>().Add(entity);
            await SaveChanges();
        }

        public async Task<T> ObterPorId(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> ObterTodos(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).AsQueryable<T>();
        }

        public IQueryable<T> ObterTodos()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public async Task Remover(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var x = e.Message;
                throw;
            }
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
