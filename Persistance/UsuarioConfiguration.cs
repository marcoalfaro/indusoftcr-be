using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class UsuarioConfiguration
    {
	    public static Action<EntityTypeBuilder<Usuario>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
				    entity.ToTable("usuario");

				    entity.Property(e => e.Id).HasColumnName("id");

				    entity.Property(e => e.Activo)
					    .HasColumnName("activo")
					    .HasDefaultValueSql("false");

				    entity.Property(e => e.Borrar).HasColumnName("borrar");

				    entity.Property(e => e.Clave)
					    .IsRequired()
					    .HasColumnName("clave");

				    entity.Property(e => e.Cotizar).HasColumnName("cotizar");

				    entity.Property(e => e.Crear).HasColumnName("crear");

				    entity.Property(e => e.Empresaid).HasColumnName("empresaid");

				    entity.Property(e => e.Nombre)
					    .IsRequired()
					    .HasColumnName("nombre");

				    entity.Property(e => e.Nombreusuario)
					    .IsRequired()
					    .HasColumnName("nombreusuario");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Usuario)
					    .HasForeignKey(d => d.Empresaid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("usuario_empresaid_fkey");
				};
		    }
	    }
    }
}
