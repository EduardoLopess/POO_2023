using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FullName, map => map.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(dest => dest.AddressesDTO, map => map.MapFrom(src => src.Addresses));
            
            CreateMap<Address, AddressDTO>();
                

            CreateMap<Volunteering, VolunteeringDTO>()
                .ForMember(dest => dest.BenefitDTOs, map => map.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.ResposibilityDTOs, map => map.MapFrom(src => src.Responsibility));

            CreateMap<Institute, InstituteDTO>();

            CreateMap<Benefit, BenefitDTO>();

            CreateMap<Responsibility, ResponsabilityDTO>();

            CreateMap<DonationMaterial, DonationMaterialDTO>();

            CreateMap<DonationPoint, DonationPointDTO>();    
        
        }
    }
}