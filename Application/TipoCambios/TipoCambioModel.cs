using System;
using Application.Base;

namespace Application.TipoCambios
{
    public class TipoCambioModel: CompanyModel
    {
	    public DateTime Fecha { get; set; }
	    public decimal Monto { get; set; }
	}
}
