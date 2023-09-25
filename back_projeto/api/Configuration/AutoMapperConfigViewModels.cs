using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;

namespace api.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}