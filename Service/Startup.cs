using Application.Base;
using Application.Clientes;
using Application.Cotizaciones;
using Application.Interfaces;
using Application.Lineas;
using Application.Mapping;
using Application.Materiales;
using Application.TipoCambios;
using Application.Vendedores;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Domain;
using Domain.Base;
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


            //if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();


            //app.UseMvc(routes =>
            //{
            //	//routes.Ma
            //	//routes.MapRoute("withNoAction", "{controller=Home}/{id?}");
            //	//routes.MapRoute("default", "{controller=Home}/{action?}/{id?}");

            //});
            app.UseMvcWithDefaultRoute();

            MapEntities();

            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //	name: "DefaultApi",
            //	routeTemplate: "api/{controller}/{id}",
            //	defaults: new { id = RouteParameter.Optional }

        }

        private static void MapEntities()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddCollectionMappers();

                cfg.CreateMap<Linea, LineaModel>();
                cfg.CreateMap<LineaModel, Linea>();
                cfg.CreateMap<Cliente, ClienteModel>();
                cfg.CreateMap<ClienteModel, Cliente>();
                cfg.CreateMap<Material, MaterialModel>();
                cfg.CreateMap<MaterialModel, Material>();
                cfg.CreateMap<TipoCambio, TipoCambioModel>();
                cfg.CreateMap<TipoCambioModel, TipoCambio>();
                cfg.CreateMap<Vendedor, VendedorModel>();
                cfg.CreateMap<VendedorModel, Vendedor>();
                cfg.CreateMap<Cotizacion, CotizacionModel>();
                cfg.CreateMap<CotizacionModel, Cotizacion>()
                    .ForMember(m => m.Cliente, o => o.Ignore())
                    .ForMember(m => m.Usuario, o => o.Ignore())
                    .ForMember(m => m.Vendedor, o => o.Ignore())
                    .ForMember(m => m.Material, o => o.Ignore())
                    .ForMember(m => m.Linea, o => o.Ignore())
                    .ForMember(m => m.TipoCambio, o => o.Ignore());

                cfg.CreateMap<ListItem, Linea>();
                cfg.CreateMap<ListItem, Material>();
                cfg.CreateMap<ListItem, Empresa>();
                cfg.CreateMap<ListItem, Usuario>();
                cfg.CreateMap<ListItem, Vendedor>();
                cfg.CreateMap<ListItem, Material>();
                cfg.CreateMap<ListItemMonto, TipoCambio>();
                cfg.CreateMap<Linea, ListItem>();
                cfg.CreateMap<Material, ListItem>();
                cfg.CreateMap<Empresa, ListItem>();
                cfg.CreateMap<Usuario, ListItem>();
                cfg.CreateMap<Vendedor, ListItem>();
                cfg.CreateMap<Material, ListItem>();
                cfg.CreateMap<TipoCambio, ListItemMonto>();
            });
        }
    }
}
