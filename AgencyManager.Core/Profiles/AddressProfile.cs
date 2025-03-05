using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Responses.DTOs;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressRequest, Address>();
            CreateMap<UpdateAddressRequest, Address>();

            CreateMap<ViaCepDto, Address>()
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Cep))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Logradouro))
            .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Bairro))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Localidade))
            .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Complemento))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Uf));
        }        
    }
}
