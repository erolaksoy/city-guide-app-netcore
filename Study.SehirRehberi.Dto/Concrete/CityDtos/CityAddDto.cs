using Study.SehirRehberi.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Dto.Concrete.CityDtos
{
    public class CityAddDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
    }
}
