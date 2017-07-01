using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
	    DbSet<Cliente> Clientes { get; set; }
	    DbSet<Cotizacion> Cotizaciones { get; set; }
	    DbSet<Empresa> Empresas { get; set; }
	    DbSet<EmpresaConfig> EmpresaConfigs { get; set; }
	    DbSet<Linea> Lineas { get; set; }
	    DbSet<Material> Materiales { get; set; }
	    DbSet<Precio> Precios { get; set; }
	    DbSet<TipoCambio> TipoCambios { get; set; }
	    DbSet<Usuario> Usuarios { get; set; }
	    DbSet<Vendedor> Vendedores { get; set; }
		
		void Save();
	    DbSet<T> GetDbSet<T>() where T : class;
	}
}
