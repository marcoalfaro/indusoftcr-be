using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class LineaConfiguration
    {
	    public static Action<EntityTypeBuilder<Linea>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
				    entity.ToTable("linea");

				    entity.Property(e => e.Id).HasColumnName("id");

				    entity.Property(e => e.Activo)
					    .HasColumnName("activo")
					    .HasDefaultValueSql("true");

				    entity.Property(e => e.Empresaid).HasColumnName("empresaid");

				    entity.Property(e => e.Nombre)
					    .IsRequired()
					    .HasColumnName("nombre");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Linea)
					    .HasForeignKey(d => d.Empresaid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("linea_empresaid_fkey");
				};
		    }
	    }
    }
}
