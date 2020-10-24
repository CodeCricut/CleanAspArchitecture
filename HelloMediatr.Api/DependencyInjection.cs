using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace HelloMediatr.Api
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApi(this IServiceCollection services)
		{
			// Register the swagger services
			services.AddSwaggerGen();
			services.AddControllers();
			//services.AddMvcCore().AddApiExplorer();

			services.AddAuthentication();
			services.AddAuthorization();

			services.AddHttpContextAccessor();
			return services;
		}
	}
}
