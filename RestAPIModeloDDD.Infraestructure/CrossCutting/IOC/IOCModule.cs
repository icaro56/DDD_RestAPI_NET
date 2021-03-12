using Microsoft.Extensions.DependencyInjection;
using RestAPIModeloDDD.Application;
using RestAPIModeloDDD.Domain.Core.Interfaces.Repositories;
using RestAPIModeloDDD.Domain.Services;
using RestAPIModeloDDD.Infraestructure.CrossCutting.IOC.Base;
using RestAPIModeloDDD.Infraestructure.CrossCutting.IOC.Extensions;
using RestAPIModeloDDD.Infraestructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Infraestructure.CrossCutting.IOC
{
    public class IOCModule : Module
    {
        protected override void Load(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.RegisterAsImplementedInterfaces<ApplicationServiceClient>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<ApplicationServiceProduct>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<ServiceClient>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<ServiceProduct>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<RepositoryClient>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<RepositoryProduct>(ServiceLifetime.Singleton);
        }
    }
}
