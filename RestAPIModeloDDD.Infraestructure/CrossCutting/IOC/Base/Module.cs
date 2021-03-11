using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Infraestructure.CrossCutting.IOC.Base
{
	public abstract class Module
	{
		public void Configure(IServiceCollection services)
		{
			Load(services);
		}

		protected abstract void Load(IServiceCollection services);
	}
}
