using Application.Base;
using Domain;
using Domain.Base;

namespace Application.Clientes
{
    public class ClienteModel: CompanyModel
    {
	    public string Nombre { get; set; }
	    public string Cedula { get; set; }
	    public string Telefono { get; set; }
	    public string ContactoNombre { get; set; }
	    public string ContactoTelefono { get; set; }
	    public string ContactoExtension { get; set; }
	    public string ContactoCorreo { get; set; }

	    public override void UpdateEntityFields(ApplicationEntity entity)
	    {
		    var cliente = (Cliente)entity;
		    cliente.Nombre = Nombre;
		    cliente.Cedula = Cedula;
		    cliente.Telefono = Telefono;
		    cliente.ContactoNombre = ContactoNombre;
		    cliente.ContactoTelefono = ContactoTelefono;
		    cliente.ContactoExtension = ContactoExtension;
		    cliente.ContactoCorreo = ContactoCorreo;
			base.UpdateEntityFields(cliente);
	    }
	}
}
