using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.DataAccess.Interfaces
{
    public interface ICityDal : IGenericDal<City>
    {
        Task<City> GetCityWithPhotosById(int id);
    }
}
