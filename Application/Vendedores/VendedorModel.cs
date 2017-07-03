using Application.Generic;

namespace Application.Vendedores
{
    public class VendedorModel: CompanyModel
    {
	    public string Nombre { get; set; }
	    public string Email { get; set; }
	    public string Telefono { get; set; }
	    public string Beeper { get; set; }
	}
}
