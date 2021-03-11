using Microsoft.Extensions.DependencyInjection;
using RestAPIModeloDDD.Infraestructure.CrossCutting.IOC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = RestAPIModeloDDD.Infraestructure.CrossCutting.IOC.Base.Module;

namespace RestAPIModeloDDD.Infraestructure.CrossCutting.IOC.Extensions
{
    public static class ModulesExtension
    {
		public static void RegisterModules(this IServiceCollection services, Assembly assembly)
		{
			foreach (Type tp in assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Module))))
			{
				if (Activator.CreateInstance(tp) is Module module)
					module.Configure(services);
			}
		}

		public static void RegisterAsImplementedInterfaces<TService>(this IServiceCollection services, ServiceLifetime lifetime)
		{
			var interfaces = typeof(TService).GetTypeInfo().ImplementedInterfaces
											.Where(i => i != typeof(IDisposable) && (i.IsPublic));

			foreach (Type interfaceType in interfaces)
				services.Add(new ServiceDescriptor(interfaceType, typeof(TService), lifetime));
		}
	}
}
