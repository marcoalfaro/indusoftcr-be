using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class CotizacionConfiguration
    {
	    public static Action<EntityTypeBuilder<Cotizacion>> Configuration
	    {
		    get
		    {
			    return entity =>
			    {
				    entity.ToTable("cotizacion");

				    entity.Property(e => e.Id).HasColumnName("id");
				    entity.Property(e => e.Altura).HasColumnName("altura");
				    entity.Property(e => e.Aplicada).HasColumnName("aplicada");
				    entity.Property(e => e.Base).HasColumnName("base");
				    entity.Property(e => e.Cantidad).HasColumnName("cantidad");
				    entity.Property(e => e.Clienteid).HasColumnName("clienteid");
				    entity.Property(e => e.Cuatricromia).HasColumnName("cuatricromia");
				    entity.Property(e => e.Cubrimiento).HasColumnName("cubrimiento");
				    entity.Property(e => e.Divancho).HasColumnName("divancho");
				    entity.Property(e => e.Divlargo).HasColumnName("divlargo");
				    entity.Property(e => e.Doblez).HasColumnName("doblez");
				    entity.Property(e => e.Empresaid).HasColumnName("empresaid");
				    entity.Property(e => e.Fecaplicada).HasColumnName("fecaplicada");
				    entity.Property(e => e.Fecha).HasColumnName("fecha");
				    entity.Property(e => e.Fecregistro).HasColumnName("fecregistro");
				    entity.Property(e => e.Laminas).HasColumnName("laminas");
				    entity.Property(e => e.Lineaid).HasColumnName("lineaid");
				    entity.Property(e => e.Materialid).HasColumnName("materialid");
				    entity.Property(e => e.Montaje).HasColumnName("montaje");
				    entity.Property(e => e.Numpedido).HasColumnName("numpedido");
				    entity.Property(e => e.Observacion).HasColumnName("observacion");
				    entity.Property(e => e.Otro).HasColumnName("otro");
				    entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
				    entity.Property(e => e.Porcevento).HasColumnName("porcevento");
				    entity.Property(e => e.Precioarte).HasColumnName("precioarte");
				    entity.Property(e => e.Preciocorte).HasColumnName("preciocorte");
				    entity.Property(e => e.Precioimpresion).HasColumnName("precioimpresion");
				    entity.Property(e => e.Preciomaterial).HasColumnName("preciomaterial");
				    entity.Property(e => e.Preciomolde).HasColumnName("preciomolde");
				    entity.Property(e => e.Preciopositivo).HasColumnName("preciopositivo");
				    entity.Property(e => e.Preciosolvente).HasColumnName("preciosolvente");
				    entity.Property(e => e.Preciotintas).HasColumnName("preciotintas");
				    entity.Property(e => e.Preciounitario).HasColumnName("preciounitario");
				    entity.Property(e => e.Rendimiento).HasColumnName("rendimiento");
				    entity.Property(e => e.Subtotal).HasColumnName("subtotal");
				    entity.Property(e => e.Tintas).HasColumnName("tintas");
				    entity.Property(e => e.Tipocambioid).HasColumnName("tipocambioid");
				    entity.Property(e => e.Totalcol).HasColumnName("totalcol");
				    entity.Property(e => e.Totalusd).HasColumnName("totalusd");
				    entity.Property(e => e.Troquel).HasColumnName("troquel");
				    entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");
				    entity.Property(e => e.Vendedorid).HasColumnName("vendedorid");

				    entity.HasOne(d => d.Cliente)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.Clienteid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_clienteid_fkey");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.Empresaid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_empresaid_fkey");

				    entity.HasOne(d => d.Material)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.Materialid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_materialid_fkey");

				    entity.HasOne(d => d.TipoCambio)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.Tipocambioid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_tipocambioid_fkey");

				    entity.HasOne(d => d.Usuario)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.Usuarioid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_usuarioid_fkey");

				    entity.HasOne(d => d.Vendedor)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.Vendedorid)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_vendedorid_fkey");
			    };
		    }
	    }
	}
}
