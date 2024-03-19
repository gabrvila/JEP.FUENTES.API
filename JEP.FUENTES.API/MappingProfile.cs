using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace JEP.FUENTES.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entidad, EntidadDto>();
            CreateMap<EntidadForCreationDto, Entidad>();
            CreateMap<EntidadForUpdateDto, Entidad>();
            CreateMap<UsuarioForCreationDto, Usuario>()
                .ForSourceMember(x => x.Contrasenna, y => y.DoNotValidate());
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(nameof(UsuarioDto.NombreCompleto),
                              opt => opt.MapFrom(x => string.Join(' ', x.PrimerNombre, x.SegundoNombre, 
                                                                       x.PrimerApellido, x.SegundoApellido)));
        }
    }
}
