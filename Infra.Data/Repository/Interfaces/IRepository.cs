using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Criar(T entity);
        Task Atualizar(T entity);
        Task Remover(T entity);
        Task<T> ObterPorId(Expression<Func<T, bool>> predicate);
        IQueryable<T> ObterTodos();
    }
}
