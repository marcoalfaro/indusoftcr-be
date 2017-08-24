using Application.Base;
using Domain;
using Domain.Base;

namespace Application.Vendedores
{
    public class VendedorModel: CompanyModel
    {
	    public string Nombre { get; set; }
	    public string Email { get; set; }
	    public string Telefono { get; set; }
	    public string Beeper { get; set; }

	    public override void UpdateEntityFields(ApplicationEntity entity)
	    {
		    var vendedor = (Vendedor)entity;
		    vendedor.Nombre = Nombre;
		    vendedor.Email = Email;
		    vendedor.Telefono = Telefono;
		    vendedor.Beeper = Beeper;
			base.UpdateEntityFields(vendedor);
	    }
	}
}
