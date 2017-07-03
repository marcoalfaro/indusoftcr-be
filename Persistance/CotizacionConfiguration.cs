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
					entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValueSql("true");
					entity.Property(e => e.Altura).HasColumnName("altura");
				    entity.Property(e => e.Aplicada).HasColumnName("aplicada");
				    entity.Property(e => e.Base).HasColumnName("base");
				    entity.Property(e => e.Cantidad).HasColumnName("cantidad");
				    entity.Property(e => e.ClienteId).HasColumnName("clienteid");
				    entity.Property(e => e.Cuatricromia).HasColumnName("cuatricromia");
				    entity.Property(e => e.Cubrimiento).HasColumnName("cubrimiento");
				    entity.Property(e => e.DivAncho).HasColumnName("divancho");
				    entity.Property(e => e.DivLargo).HasColumnName("divlargo");
				    entity.Property(e => e.Doblez).HasColumnName("doblez");
				    entity.Property(e => e.EmpresaId).HasColumnName("empresaid");
				    entity.Property(e => e.FecAplicada).HasColumnName("fecaplicada");
				    entity.Property(e => e.Fecha).HasColumnName("fecha");
				    entity.Property(e => e.FecRegistro).HasColumnName("fecregistro");
				    entity.Property(e => e.Laminas).HasColumnName("laminas");
				    entity.Property(e => e.LineaId).HasColumnName("lineaid");
				    entity.Property(e => e.MaterialId).HasColumnName("materialid");
				    entity.Property(e => e.Montaje).HasColumnName("montaje");
				    entity.Property(e => e.NumPedido).HasColumnName("numpedido");
				    entity.Property(e => e.Observacion).HasColumnName("observacion");
				    entity.Property(e => e.Otro).HasColumnName("otro");
				    entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
				    entity.Property(e => e.PorcEvento).HasColumnName("porcevento");
				    entity.Property(e => e.PrecioArte).HasColumnName("precioarte");
				    entity.Property(e => e.PrecioCorte).HasColumnName("preciocorte");
				    entity.Property(e => e.PrecioImpresion).HasColumnName("precioimpresion");
				    entity.Property(e => e.PrecioMaterial).HasColumnName("preciomaterial");
				    entity.Property(e => e.PrecioMolde).HasColumnName("preciomolde");
				    entity.Property(e => e.PrecioPositivo).HasColumnName("preciopositivo");
				    entity.Property(e => e.PrecioSolvente).HasColumnName("preciosolvente");
				    entity.Property(e => e.PrecioTintas).HasColumnName("preciotintas");
				    entity.Property(e => e.PrecioUnitario).HasColumnName("preciounitario");
				    entity.Property(e => e.Rendimiento).HasColumnName("rendimiento");
				    entity.Property(e => e.Subtotal).HasColumnName("subtotal");
				    entity.Property(e => e.Tintas).HasColumnName("tintas");
				    entity.Property(e => e.TipocambioId).HasColumnName("tipocambioid");
				    entity.Property(e => e.TotalCol).HasColumnName("totalcol");
				    entity.Property(e => e.TotalUsd).HasColumnName("totalusd");
				    entity.Property(e => e.Troquel).HasColumnName("troquel");
				    entity.Property(e => e.UsuarioId).HasColumnName("usuarioid");
				    entity.Property(e => e.VendedorId).HasColumnName("vendedorid");

				    entity.HasOne(d => d.Cliente)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.ClienteId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_clienteid_fkey");

				    entity.HasOne(d => d.Empresa)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.EmpresaId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_empresaid_fkey");

				    entity.HasOne(d => d.Material)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.MaterialId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_materialid_fkey");

				    entity.HasOne(d => d.TipoCambio)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.TipocambioId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_tipocambioid_fkey");

				    entity.HasOne(d => d.Usuario)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.UsuarioId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_usuarioid_fkey");

				    entity.HasOne(d => d.Vendedor)
					    .WithMany(p => p.Cotizacion)
					    .HasForeignKey(d => d.VendedorId)
					    .OnDelete(DeleteBehavior.Restrict)
					    .HasConstraintName("cotizacion_vendedorid_fkey");
			    };
		    }
	    }
	}
}
