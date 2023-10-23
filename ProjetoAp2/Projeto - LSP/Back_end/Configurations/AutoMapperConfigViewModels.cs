using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.ViewModels;

namespace Back_end.Configurations
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}