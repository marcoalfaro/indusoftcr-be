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

		    });
		}
	}
}
