using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class EmpresaConfiguration
    {
	    public static Action<EntityTypeBuilder<Empresa>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
					entity.ToTable("empresa");

				    entity.Property(e => e.Id).HasColumnName("id");

				    entity.Property(e => e.Activo)
					    .HasColumnName("activo")
					    .HasDefaultValueSql("false");

				    entity.Property(e => e.Nombre)
					    .IsRequired()
					    .HasColumnName("nombre");
				};
		    }
	    }
    }
}
