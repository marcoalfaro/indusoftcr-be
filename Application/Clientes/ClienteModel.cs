using Domain.Base;

namespace Application.Clientes
{
    public class ClienteModel: ActivableEntity
    {
	    public int EmpresaId { get; set; }
	    public string Nombre { get; set; }
	    public string Cedula { get; set; }
	    public string Telefono { get; set; }
	    public string ContactoNombre { get; set; }
	    public string ContactoTelefono { get; set; }
	    public string ContactoExtension { get; set; }
	    public string ContactoCorreo { get; set; }
    }
}
