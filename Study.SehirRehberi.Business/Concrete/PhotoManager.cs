using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Business.Concrete
{
    public class PhotoManager : GenericManager<Photo>, IPhotoService
    {
        private readonly IUnitOfWork _uow;
        public PhotoManager(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
    }
}
