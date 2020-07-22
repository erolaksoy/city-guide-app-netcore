using Study.SehirRehberi.Entitiy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Entitiy.Concrete
{
    public class Photo : ITable
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }


    }
}
