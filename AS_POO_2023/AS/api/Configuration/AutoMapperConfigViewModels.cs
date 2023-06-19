using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;

namespace api.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
            CreateMap<LivroViewModel, Livro>();
            CreateMap<AutorViewModel, Autor>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<EmprestimoViewModel, Emprestimo>();
        }
    }
}