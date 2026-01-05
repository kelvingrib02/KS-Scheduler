using KS.Scheduler.Domain.Entities.Base;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KS.Scheduler.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly KSSchedulerDbContext Db;
        protected readonly DbSet<T> DbSet;

        protected Repository(KSSchedulerDbContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Adicionar(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual void Atualizar(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remover(Guid id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}