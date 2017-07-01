using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Persistance
{
    public class DatabaseService: DbContext, IDatabaseService
    {
		public DbSet<Cliente> Clientes { get; set; }
	    public DbSet<Cotizacion> Cotizaciones { get; set; }
	    public DbSet<Empresa> Empresas { get; set; }
	    public DbSet<EmpresaConfig> EmpresaConfigs { get; set; }
	    public DbSet<Linea> Lineas { get; set; }
	    public DbSet<Material> Materiales { get; set; }
	    public DbSet<Precio> Precios { get; set; }
	    public DbSet<TipoCambio> TipoCambios { get; set; }
	    public DbSet<Usuario> Usuarios { get; set; }
	    public DbSet<Vendedor> Vendedores { get; set; }

		public void Save()
		{
			SaveChanges();
		}
		
		// TODO:  How to get ConnString in .Net Core
	    //<connectionStrings>
	    //<add name = "CleanArchitecture" connectionString="Data Source=(local);Initial Catalog=CleanArchitecture;Integrated Security=true" providerName="System.Data.SqlClient" />
	    //</connectionStrings>

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    base.OnModelCreating(modelBuilder);

		    modelBuilder.Entity(ClienteConfiguration.Configuration);
		    modelBuilder.Entity(CotizacionConfiguration.Configuration);
		    modelBuilder.Entity(EmpresaConfiguration.Configuration);
		    modelBuilder.Entity(EmpresaConfigConfiguration.Configuration);
		    modelBuilder.Entity(LineaConfiguration.Configuration);
		    modelBuilder.Entity(MaterialConfiguration.Configuration);
		    modelBuilder.Entity(PrecioConfiguration.Configuration);
		    modelBuilder.Entity(TipoCambioConfiguration.Configuration);
		    modelBuilder.Entity(UsuarioConfiguration.Configuration);
		    modelBuilder.Entity(VendedorConfiguration.Configuration);
		}
    }
}
