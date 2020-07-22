using Microsoft.EntityFrameworkCore;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Context;
using Study.SehirRehberi.DataAccess.Interfaces;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCityRepository : EfGenericRepository<City>, ICityDal
    {
        private readonly SehirRehberiContext _context;
        public EfCityRepository(SehirRehberiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<City> GetCityWithPhotosById(int id)
        {
            return await _context.Cities.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
