using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Endereco, EnderecoDTO>();
                   
        }
    }
}