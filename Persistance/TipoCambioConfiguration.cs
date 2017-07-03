using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class TipoCambioConfiguration
    {
	    public static Action<EntityTypeBuilder<TipoCambio>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
					entity.ToTable("tipocambio");

				    entity.Property(e => e.Id).HasColumnName("id");
				    entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValueSql("true");

					entity.Property(e => e.EmpresaId).HasColumnName("empresaid");

				    entity.Property(e => e.Fecha).HasColumnName("fecha");

				    entity.Property(e => e.Monto).HasColumnName("monto");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Tipocambio)
					    .HasForeignKey(d => d.EmpresaId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("tipocambio_empresaid_fkey");
				};
		    }
	    }
    }
}
