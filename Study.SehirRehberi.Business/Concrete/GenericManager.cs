using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork;
using Study.SehirRehberi.Entitiy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IUnitOfWork _uow;
        public GenericManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Delete(TEntity entity)
        {
            _uow.GetRepository<TEntity>().Delete(entity);
            _uow.SaveChanges();
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _uow.GetRepository<TEntity>().GetByFilterAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _uow.GetRepository<TEntity>().GetByIdAsync(id);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _uow.GetRepository<TEntity>().GetListAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _uow.GetRepository<TEntity>().GetListAsync(filter);
        }

        public async Task<List<TEntity>> GetListAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _uow.GetRepository<TEntity>().GetListAsync();
        }

        public async Task<List<TEntity>> GetListAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _uow.GetRepository<TEntity>().GetListAsync(filter, keySelector);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _uow.GetRepository<TEntity>().InsertAsync(entity);
            await _uow.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _uow.GetRepository<TEntity>().Update(entity);
            _uow.SaveChanges();
        }
    }
}
