using Domain.Base;

namespace Domain
{
    public class Precio: CompanyEntity
    {
        public decimal Molde { get; set; }
        public decimal Tinta { get; set; }
        public decimal Positivo { get; set; }
        public decimal Arte { get; set; }
        public decimal Solvente { get; set; }
        public decimal Corte { get; set; }
        public decimal Velocidad { get; set; }
        public decimal HoraImpresion { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
