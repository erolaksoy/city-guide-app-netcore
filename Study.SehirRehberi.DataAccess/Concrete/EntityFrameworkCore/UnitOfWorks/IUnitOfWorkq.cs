using Study.SehirRehberi.DataAccess.Interfaces;
using Study.SehirRehberi.Entitiy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericDal<TEntity> GetRepository<TEntity>() where TEntity : class, ITable, new();
        IPhotoDal PhotoDal { get; set; }
        IUserDal UserDal { get; set; }
        ICityDal CityDal { get; set; }
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
