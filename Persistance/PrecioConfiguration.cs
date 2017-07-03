using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class PrecioConfiguration
    {
	    public static Action<EntityTypeBuilder<Precio>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
				    entity.ToTable("precio");

				    entity.Property(e => e.Id).HasColumnName("id");
				    entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValueSql("true");

					entity.Property(e => e.Arte).HasColumnName("arte");

				    entity.Property(e => e.Corte).HasColumnName("corte");

				    entity.Property(e => e.EmpresaId).HasColumnName("empresaid");

				    entity.Property(e => e.HoraImpresion).HasColumnName("horaimpresion");

				    entity.Property(e => e.Molde).HasColumnName("molde");

				    entity.Property(e => e.Positivo).HasColumnName("positivo");

				    entity.Property(e => e.Solvente).HasColumnName("solvente");

				    entity.Property(e => e.Tinta).HasColumnName("tinta");

				    entity.Property(e => e.Velocidad).HasColumnName("velocidad");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Precio)
					    .HasForeignKey(d => d.EmpresaId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("precio_empresaid_fkey");
				};
		    }
	    }
    }
}
