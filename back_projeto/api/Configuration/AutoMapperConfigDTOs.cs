using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.NomeCompleto, map => map.MapFrom(src => $"{src.Nome} {src.SobreNome}"));
                    
            CreateMap<Endereco, EnderecoDTO>();
                   
        }
    }
} 