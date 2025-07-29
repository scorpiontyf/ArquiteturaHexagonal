using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> Adicionar(T entity);
        Task<bool> Atualizar(Guid id, T entity);
        Task<bool> Excluir(Guid id);
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
    }
}
