using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class MaterialConfiguration
    {
	    public static Action<EntityTypeBuilder<Material>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
					entity.ToTable("material");

				    entity.Property(e => e.Id).HasColumnName("id");

				    entity.Property(e => e.Activo)
					    .HasColumnName("activo")
					    .HasDefaultValueSql("false");

				    entity.Property(e => e.Altura).HasColumnName("altura");

				    entity.Property(e => e.Base).HasColumnName("base");

				    entity.Property(e => e.Codigoinventario).HasColumnName("codigoinventario");

				    entity.Property(e => e.Costoinventario).HasColumnName("costoinventario");

				    entity.Property(e => e.Empresaid).HasColumnName("empresaid");

				    entity.Property(e => e.Nombre)
					    .IsRequired()
					    .HasColumnName("nombre");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Material)
					    .HasForeignKey(d => d.Empresaid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("material_empresaid_fkey");
				};
		    }
	    }
    }
}
