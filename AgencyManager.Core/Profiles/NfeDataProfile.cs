using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Nfe;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class NfeDataProfile : Profile
    {
        public NfeDataProfile()
        {
            CreateMap<CreateNfeDataRequest, NfeData>()
            .ConstructUsing(src => new NfeData(
                src.Name,
                src.Cnpj,
                src.Ie,
                src.Address.ZipCode,
                src.Address.Street,
                src.Address.Number,
                src.Address.Neighborhood,
                src.Address.City,
                src.Address.State,
                src.Address.Complement
            ));

            CreateMap<UpdateNfeDataRequest, NfeData>()
             .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
             .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
             .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
             .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Address.Neighborhood))
             .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
             .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
             .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Address.Complement));

        }
    }
}
