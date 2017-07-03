using Domain.Base;

namespace Domain
{
    public class Linea: CompanyEntity
    {
        public int Empresaid { get; set; }
        public string Nombre { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
