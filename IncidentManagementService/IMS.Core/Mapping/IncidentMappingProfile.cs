using AutoMapper;
using IMS.Core.Dtos;
using IMS.Core.Entities;

namespace IMS.Core.Mapping
{
    public class IncidentMappingProfile : Profile
    {
        public IncidentMappingProfile()
        {
            #region Incident
            CreateMap<IncidentDto, Incident>()
                    .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Incident, IncidentDto>();
            #endregion
            
        }
    }
}
