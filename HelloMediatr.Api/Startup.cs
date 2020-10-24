using FluentValidation.AspNetCore;
using HelloMediatr.Api.Middleware;
using HelloMediatr.Application;
using HelloMediatr.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloMediatr.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddApplication();
			services.AddInfrastructure(Configuration);
			services.AddApi();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();


			// Register the Swagger generator and the Swagger UI middlewares
			app.UseSwagger();
			app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "HelloMediatr"));

			app.UseRouting();

			app.UseAuthorization();

			app.UseMiddleware<CustomExceptionHandlerMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
