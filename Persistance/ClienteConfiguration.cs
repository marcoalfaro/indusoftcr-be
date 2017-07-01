using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class ClienteConfiguration
    {
	    public static Action<EntityTypeBuilder<Cliente>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
				    entity.ToTable("cliente");

				    entity.Property(e => e.Id).HasColumnName("id");

				    entity.Property(e => e.Activo)
					    .HasColumnName("activo")
					    .HasDefaultValueSql("false");

				    entity.Property(e => e.Cedula).HasColumnName("cedula");

				    entity.Property(e => e.Contactocorreo).HasColumnName("contactocorreo");

				    entity.Property(e => e.Contactoextension).HasColumnName("contactoextension");

				    entity.Property(e => e.Contactonombre).HasColumnName("contactonombre");

				    entity.Property(e => e.Contactotelefono).HasColumnName("contactotelefono");

				    entity.Property(e => e.Empresaid).HasColumnName("empresaid");

				    entity.Property(e => e.Nombre)
					    .IsRequired()
					    .HasColumnName("nombre");

				    entity.Property(e => e.Telefono).HasColumnName("telefono");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Cliente)
					    .HasForeignKey(d => d.Empresaid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cliente_empresaid_fkey");
			    };
		    }
	    }
    }
}
