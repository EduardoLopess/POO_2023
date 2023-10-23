using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back_end.Models.Domain.DTOs;
using Back_end.Models.Domain.Entities;

namespace Back_end.Configurations
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<Endereco, EnderecoDTO>();

            CreateMap<Instituto, InstitutoDTO>()
                .ForMember(dest => dest.EnderecoDTO, map => map.MapFrom(src => src.Endereco));
            
            CreateMap<Voluntariado, VoluntariadoDTO>()
                .ForMember(dest => dest.BeneficioDTOs, map => map.MapFrom(src => src.Beneficios))
                .ForMember(dest => dest.ResponsabilidadeDTOs, map => map.MapFrom(src => src.Responsabilidade));


            CreateMap<VoluntariadoBeneficio, VoluntariadoBeneficioDTO>();
            
            CreateMap<VoluntariadoResponsabilidade, VoluntariadoResponsabilidadeDTO>();

            CreateMap<VoluntariadoBeneficio, VoluntariadoBeneficio>();

            CreateMap<PontoDoacao, PontoDoacaoDTO>();
            
            CreateMap<MaterialDoacao, MaterialDoacaoDTO>();
        }
    }
}