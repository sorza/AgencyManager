using AgencyManager.Core.DTOs;
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
            CreateMap<Contact, UpdateContactRequest>();
            CreateMap<UpdateContactRequest, Contact>();

            CreateMap<Contact, ContactDto>();
        }
    }
}
