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
    public class PhotoManager : GenericManager<Photo>, IPhotoService
    {
        private readonly IPhotoDal _photoDal;
        public PhotoManager(IPhotoDal photoDal) : base(photoDal)
        {
            _photoDal = photoDal;
        }

        public async Task<List<Photo>> GetPhotosByCityId(int cityId)
        {
            return await _photoDal.GetListAsync(x => x.CityId == cityId);
        }
    }
}
