using Microsoft.Extensions.DependencyInjection;
using RestAPIModeloDDD.Application;
using RestAPIModeloDDD.Application.Mapper;
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

            services.RegisterAsImplementedInterfaces<ApplicationServiceCliente>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<ApplicationServiceProduto>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<ServiceCliente>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<ServiceProduto>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<RepositoryCliente>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<RepositoryProduto>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<MapperCliente>(ServiceLifetime.Singleton);
            services.RegisterAsImplementedInterfaces<MapperProduto>(ServiceLifetime.Singleton);
        }
    }
}
