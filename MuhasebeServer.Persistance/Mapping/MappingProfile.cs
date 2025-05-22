using AutoMapper;
using MuhasebeServer.Domain.AppEntities.Identity;
using MuhasebeServer.Domain.AppEntities;
using MuhasebeServer.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

namespace MuhasebeServer.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommandRequest, Company>();
        }
    }
}
