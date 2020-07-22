using Study.SehirRehberi.Entitiy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Entitiy.Concrete
{
    public class User : ITable
    {
        public User()
        {
            Cities = new List<City>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<City> Cities { get; set; }

    }
}
