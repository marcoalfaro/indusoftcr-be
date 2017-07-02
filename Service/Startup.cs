using Application.Generic;
using Application.Interfaces;
using Application.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Service
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();
			services.AddDbContext<DatabaseService>(options => options.UseNpgsql(Configuration.GetConnectionString("Indusoft")));
			services.AddScoped(typeof(IGetListQuery<,>), typeof(GetListQuery<,>));
			services.AddScoped(typeof(IGetDetailQuery<,>), typeof(GetDetailQuery<,>));
			services.AddScoped(typeof(IGetActiveListQuery<,>), typeof(GetActiveListQuery<,>));
			services.AddScoped(typeof(IGetItemListQuery<>), typeof(GetListItemQuery<>));
			services.AddScoped<IDatabaseService, DatabaseService>();
			services.AddSingleton<IConfigurationProvider>(EntityMapper.Configuration());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc(routes =>
			{
				routes.MapRoute("withNoAction", "{controller=Home}/{id?}");
				routes.MapRoute("default", "{controller=Home}/{action?}/{id?}");
			});
		}
	}
}
