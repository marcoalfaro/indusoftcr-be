using Domain;

namespace Application.Clientes
{
    public class ClienteModel: BaseModel<Cliente>
    {
	    public int EmpresaId { get; set; }
	    public string Nombre { get; set; }
	    public string Cedula { get; set; }
	    public string Telefono { get; set; }
	    public string ContactoNombre { get; set; }
	    public string ContactoTelefono { get; set; }
	    public string ContactoExtension { get; set; }
	    public string ContactoCorreo { get; set; }
	    public bool Activo { get; set; }

	    public ClienteModel(Cliente entity)
	    {
			Id = entity.Id;
		    Nombre = entity.Nombre;
		    Cedula = entity.Cedula;
		    Telefono = entity.Telefono;
		    ContactoNombre = entity.ContactoNombre;
		    ContactoTelefono = entity.ContactoTelefono;
		    ContactoCorreo = entity.ContactoCorreo;
		    ContactoExtension = entity.ContactoExtension;
		    EmpresaId = entity.EmpresaId;
	    }

	    public override void CopyFields(Cliente entity)
	    {
		    entity.Id = Id;
		    entity.Nombre = Nombre;
		    entity.Cedula = Cedula;
		    entity.Telefono = Telefono;
		    entity.ContactoCorreo = ContactoCorreo;
		    entity.ContactoExtension = ContactoExtension;
		    entity.ContactoNombre = ContactoNombre;
		    entity.ContactoTelefono = ContactoTelefono;
		    entity.Activo = Activo;
		    entity.EmpresaId = EmpresaId;
	    }

	    public override Cliente ToEntity()
	    {
		    return new Cliente
		    {
			    Id = Id,
			    Nombre = Nombre,
			    Cedula = Cedula,
			    Telefono = Telefono,
			    ContactoNombre = ContactoNombre,
			    ContactoTelefono = ContactoTelefono,
			    ContactoCorreo = ContactoCorreo,
			    ContactoExtension = ContactoExtension,
			    EmpresaId = EmpresaId
		    };
	    }
    }
}
