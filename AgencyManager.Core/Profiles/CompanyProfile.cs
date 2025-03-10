﻿using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Company;
using AgencyManager.Core.Responses.DTOs;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();

            CreateMap<Company, CompanyDto>();
        }
    }
}
