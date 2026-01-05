using KS.Scheduler.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KS.Scheduler.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task Adicionar(T entity);
        Task<T> ObterPorId(Guid id);
        Task<IEnumerable<T>> ObterTodos();
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        void Atualizar(T entity);
        void Remover(Guid id);
    }
}