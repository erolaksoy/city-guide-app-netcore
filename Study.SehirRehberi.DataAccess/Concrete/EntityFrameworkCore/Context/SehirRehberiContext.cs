using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class SehirRehberiContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER = EROL; Database = StudySehirRehberiDb; Integrated Security = true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
