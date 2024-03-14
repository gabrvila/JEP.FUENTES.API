using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JEP.FUENTES.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entidad, EntidadDto>();
                //.ForCtorParam("DireccionCompleta",
                //           opt => opt.MapFrom(x => string.Join(' ', x.Direccion, x.Pais)));
            CreateMap<EntidadForCreationDto, Entidad>();
            CreateMap<EntidadForUpdateDto, Entidad>();
            CreateMap<UsuarioForRegistrationDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(nameof(UsuarioDto.NombreCompleto),
                              opt => opt.MapFrom(x => string.Join(' ', x.PrimerNombre, x.SegundoNombre, 
                                                                       x.PrimerApellido, x.SegundoApellido)));
        }
    }
}
