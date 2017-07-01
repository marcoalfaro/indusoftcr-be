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

				    entity.Property(e => e.ContactoCorreo).HasColumnName("contactocorreo");

				    entity.Property(e => e.ContactoExtension).HasColumnName("contactoextension");

				    entity.Property(e => e.ContactoNombre).HasColumnName("contactonombre");

				    entity.Property(e => e.ContactoTelefono).HasColumnName("contactotelefono");

				    entity.Property(e => e.EmpresaId).HasColumnName("empresaid");

				    entity.Property(e => e.Nombre)
					    .IsRequired()
					    .HasColumnName("nombre");

				    entity.Property(e => e.Telefono).HasColumnName("telefono");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Cliente)
					    .HasForeignKey(d => d.EmpresaId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cliente_empresaid_fkey");
			    };
		    }
	    }
    }
}
