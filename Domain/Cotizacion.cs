using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Cotizacion
    {
        public int Id { get; set; }
        public int Empresaid { get; set; }
        public int Clienteid { get; set; }
        public int Usuarioid { get; set; }
        public int Vendedorid { get; set; }
        public int Materialid { get; set; }
        public int Tipocambioid { get; set; }
        public int? Lineaid { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Preciounitario { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Porcentaje { get; set; }
        public decimal? Totalusd { get; set; }
        public decimal? Totalcol { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Montaje { get; set; }
        public decimal? Base { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Tintas { get; set; }
        public decimal? Cubrimiento { get; set; }
        public decimal? Troquel { get; set; }
        public decimal? Doblez { get; set; }
        public decimal? Cuatricromia { get; set; }
        public decimal? Otro { get; set; }
        public decimal? Porcevento { get; set; }
        public bool? Aplicada { get; set; }
        public DateTime? Fecaplicada { get; set; }
        public DateTime? Fecregistro { get; set; }
        public string Numpedido { get; set; }
        public decimal? Preciomaterial { get; set; }
        public decimal? Preciotintas { get; set; }
        public decimal? Precioarte { get; set; }
        public decimal? Precioimpresion { get; set; }
        public decimal? Preciomolde { get; set; }
        public decimal? Preciocorte { get; set; }
        public decimal? Preciopositivo { get; set; }
        public decimal? Preciosolvente { get; set; }
        public decimal? Rendimiento { get; set; }
        public decimal? Laminas { get; set; }
        public string Observacion { get; set; }
        public decimal? Divlargo { get; set; }
        public decimal? Divancho { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Material Material { get; set; }
        public virtual Tipocambio Tipocambio { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}
