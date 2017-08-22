using Application.Base;
using Domain;
using Domain.Base;

namespace Application.Materiales
{
    public class MaterialModel: CompanyModel
    {
	    public string Nombre { get; set; }
	    public decimal Altura { get; set; }
	    public decimal Base { get; set; }
	    public string CodigoInventario { get; set; }
	    public decimal CostoInventario { get; set; }

	    public override void UpdateEntityFields(ApplicationEntity entity)
	    {
		    var material = (Material)entity;
		    material.Nombre = Nombre;
		    material.Altura = Altura;
		    material.Base = Base;
		    material.CodigoInventario = CodigoInventario;
		    material.CostoInventario = CostoInventario;
			base.UpdateEntityFields(material);
	    }
	}
}
