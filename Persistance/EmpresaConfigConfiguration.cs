using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class EmpresaConfigConfiguration
    {
	    public static Action<EntityTypeBuilder<EmpresaConfig>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
				    entity.ToTable("empresaconfig");

				    entity.Property(e => e.Id)
					    .HasColumnName("id")
					    .ValueGeneratedNever();

				    entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValueSql("true");

					entity.Property(e => e.Cedula).HasColumnName("cedula");

				    entity.Property(e => e.Direccion).HasColumnName("direccion");

				    entity.Property(e => e.Email).HasColumnName("email");

				    entity.Property(e => e.Fax).HasColumnName("fax");

				    entity.Property(e => e.Impuestoventa).HasColumnName("impuestoventa");

				    entity.Property(e => e.Precioarte)
					    .HasColumnName("precioarte")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Preciocorte)
					    .HasColumnName("preciocorte")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Preciohoraimpresion)
					    .HasColumnName("preciohoraimpresion")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Preciomolde)
					    .HasColumnName("preciomolde")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Preciopositivo)
					    .HasColumnName("preciopositivo")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Preciosolvente)
					    .HasColumnName("preciosolvente")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Preciotinta)
					    .HasColumnName("preciotinta")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Preciovelocidad)
					    .HasColumnName("preciovelocidad")
					    .HasDefaultValueSql("0");

				    entity.Property(e => e.Telefono).HasColumnName("telefono");

				    entity.Property(e => e.Utilidad).HasColumnName("utilidad");

				    entity.HasOne(d => d.IdNavigation)
					    .WithOne(p => p.EmpresaConfig)
					    .HasForeignKey<EmpresaConfig>(d => d.Id)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("empresaconfig_id_fkey");
				};
		    }
	    }
    }
}
