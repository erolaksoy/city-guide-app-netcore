using Study.SehirRehberi.Entitiy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Entitiy.Concrete
{
    public class City : ITable
    {
        public City()
        {
            Photos = new List<Photo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
