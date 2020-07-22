using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Study.SehirRehberi.Business.Concrete;
using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Context;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork;
using Study.SehirRehberi.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.SehirRehberi.Business.Containers.MicrosoftIoc
{
    public static class CustomExtensions
    {

        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<SehirRehberiContext>();

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICityDal, EfCityRepository>();
            services.AddScoped<IPhotoDal, EfPhotoRepository>();
            services.AddScoped<IUserDal, EfUserRepository>();

            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<IPhotoService, PhotoManager>();
            services.AddScoped<IUserService, UserManager>();
        }
    }
}
