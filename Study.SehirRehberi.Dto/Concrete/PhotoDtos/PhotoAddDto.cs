using Microsoft.AspNetCore.Http;
using Study.SehirRehberi.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Dto.Concrete.PhotoDtos
{
    public class PhotoAddDto : IDto
    {
        public PhotoAddDto()
        {
            DateAdded = DateTime.Now;
        }

        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public IFormFile File { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int CityId { get; set; }
    }
}
