using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    internal class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactRequest, Contact>();
        }
    }
}
