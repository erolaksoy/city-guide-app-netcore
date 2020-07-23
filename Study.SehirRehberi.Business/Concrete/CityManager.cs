using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork;
using Study.SehirRehberi.DataAccess.Interfaces;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.Business.Concrete
{
    public class CityManager : GenericManager<City>, ICityService
    {
        private readonly ICityDal _cityDal;
        public CityManager(ICityDal cityDal) : base(cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task<City> GetCityWithPhotosById(int id)
        {
            return await _cityDal.GetCityWithPhotosById(id);
        }

        public async Task<List<City>> GetListCityWithPhotos()
        {
            return await _cityDal.GetListCityWithPhotos();
        }
    }
}
