using System;
using Application.Generic;

namespace Application.TipoCambios
{
    public class TipoCambioModel: CompanyModel
    {
	    public DateTime Fecha { get; set; }
	    public decimal Monto { get; set; }
	}
}
