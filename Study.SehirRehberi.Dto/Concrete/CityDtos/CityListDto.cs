using Study.SehirRehberi.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Dto.Concrete.CityDtos
{
    public class CityListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        
    }
}
