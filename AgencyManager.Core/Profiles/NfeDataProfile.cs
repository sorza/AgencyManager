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
        }
    }
}
