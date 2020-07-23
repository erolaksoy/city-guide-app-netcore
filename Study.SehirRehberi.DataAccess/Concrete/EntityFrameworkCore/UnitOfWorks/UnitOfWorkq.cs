using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Context;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Study.SehirRehberi.DataAccess.Interfaces;
using Study.SehirRehberi.Entitiy.Concrete;
using Study.SehirRehberi.Entitiy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPhotoDal PhotoDal { get; set; }
        public IUserDal UserDal { get; set; }
        public ICityDal CityDal { get; set; }

        private readonly SehirRehberiContext _context;
        public UnitOfWork(SehirRehberiContext context)
        {
            _context = context;
            PhotoDal = new EfPhotoRepository(_context);
            UserDal = new EfUserRepository(_context);
            CityDal = new EfCityRepository(_context);
        }

        public IGenericDal<TEntity> GetRepository<TEntity>() where TEntity : class, ITable, new()
        {
            return new EfGenericRepository<TEntity>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
