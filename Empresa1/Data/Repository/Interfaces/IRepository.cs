using Empresa1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Empresa1.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity 
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression);
        Task<int> SaveChanges();
    }
}
