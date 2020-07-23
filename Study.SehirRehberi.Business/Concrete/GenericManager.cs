using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork;
using Study.SehirRehberi.DataAccess.Interfaces;
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
        private readonly IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }
        public void Delete(TEntity entity)
        {
            _genericDal.Delete(entity);

        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.GetByFilterAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _genericDal.GetListAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.GetListAsync(filter);
        }

        public async Task<List<TEntity>> GetListAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _genericDal.GetListAsync();
        }

        public async Task<List<TEntity>> GetListAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _genericDal.GetListAsync(filter, keySelector);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _genericDal.InsertAsync(entity);

        }

        public void Update(TEntity entity)
        {
             _genericDal.Update(entity);

        }
    }
}
