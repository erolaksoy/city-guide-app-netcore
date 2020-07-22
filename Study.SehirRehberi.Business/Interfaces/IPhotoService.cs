using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.Business.Interfaces
{
    public interface IPhotoService : IGenericService<Photo>
    {
        Task<List<Photo>> GetPhotosByCityId(int cityId);
    }
}
