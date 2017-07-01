using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class VendedorConfiguration
    {
	    public static Action<EntityTypeBuilder<Vendedor>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
					entity.ToTable("vendedor");

				    entity.Property(e => e.Id).HasColumnName("id");

				    entity.Property(e => e.Activo)
					    .HasColumnName("activo")
					    .HasDefaultValueSql("false");

				    entity.Property(e => e.Beeper).HasColumnName("beeper");

				    entity.Property(e => e.Email).HasColumnName("email");

				    entity.Property(e => e.Empresaid).HasColumnName("empresaid");

				    entity.Property(e => e.Nombre)
					    .IsRequired()
					    .HasColumnName("nombre");

				    entity.Property(e => e.Telefono).HasColumnName("telefono");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Vendedor)
					    .HasForeignKey(d => d.Empresaid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("vendedor_empresaid_fkey");
				};
		    }
	    }
    }
}
