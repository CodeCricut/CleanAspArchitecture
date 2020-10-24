using HelloMediatr.Domain.Interfaces;
using HelloMediatr.Infrastructure.Persistence;
using HelloMediatr.Infrastructure.Persistence.Repository.Common;
using HelloMediatr.Infrastructure.Persistence.Repository.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMediatr.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			if (configuration.GetValue<bool>("UseInMemoryDatabase"))
			{
				services.AddDbContext<DbContext, HelloDbContext>(options =>
					options.UseInMemoryDatabase("HelloMediatr"));
			}
			else
			{
				services.AddDbContext<DbContext, HelloDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			}

			services.AddScoped<ITodoRepository, TodoRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}
