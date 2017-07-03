using Application.Generic;

namespace Application.Materiales
{
    public class MaterialModel: CompanyModel
    {
	    public string Nombre { get; set; }
	    public decimal? Altura { get; set; }
	    public decimal? Base { get; set; }
	    public string CodigoInventario { get; set; }
	    public decimal? CostoInventario { get; set; }
	}
}
