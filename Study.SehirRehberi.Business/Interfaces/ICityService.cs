using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.Business.Interfaces
{
    public interface ICityService : IGenericService<City>
    {
        Task<City> GetCityWithPhotosById(int id);
    }
}
