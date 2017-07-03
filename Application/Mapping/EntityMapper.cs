using AutoMapper;
using AutoMapper.Mappers;
using Domain;
using Domain.Base;

namespace Application.Mapping
{
    public class EntityMapper
    {
	    public static MapperConfiguration Configuration()
	    {
		    return  new MapperConfiguration(c => {
			    c.AddConditionalObjectMapper().Where((m, e) => e.Name == m.Name + "Model");
			    c.AddConditionalObjectMapper().Where((e, m) => e.Name == m.Name + "Model");

			    c.CreateMap<Cliente, ListItem>();
			    c.CreateMap<Cotizacion, ListItem>();
			    c.CreateMap<Empresa, ListItem>();
				c.CreateMap<Usuario, ListItem>();
			    c.CreateMap<Vendedor, ListItem>();
			    c.CreateMap<Material, ListItem>();
			    c.CreateMap<TipoCambio, ListItemMonto>();
			    c.CreateMap<Linea, ListItem>();

			});
		}
	}
}
