using Study.SehirRehberi.Dto.Interfaces;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Dto.Concrete.CityDtos
{
    public class CityDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
