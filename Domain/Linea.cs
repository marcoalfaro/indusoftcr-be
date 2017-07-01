using Domain.Base;

namespace Domain
{
    public class Linea: BaseEntity
    {
        public int Empresaid { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
