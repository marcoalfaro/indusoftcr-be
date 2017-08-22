using Application.Base;
using Domain;
using Domain.Base;

namespace Application.Lineas
{
    public class LineaModel: CompanyModel
    {
	    public string Nombre { get; set; }
		public override void UpdateEntityFields(ApplicationEntity entity)
		{
			var linea = (Linea) entity;
			linea.Nombre = Nombre;
			base.UpdateEntityFields(linea);
		}
    }
}
