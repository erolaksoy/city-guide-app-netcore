using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Context;
using Study.SehirRehberi.DataAccess.Interfaces;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPhotoRepository : EfGenericRepository<Photo>, IPhotoDal
    {
        public EfPhotoRepository(SehirRehberiContext context) : base(context)
        {
        }
    }
}
