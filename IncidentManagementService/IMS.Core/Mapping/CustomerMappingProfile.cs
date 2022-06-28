using AutoMapper;
using IMS.Core.Dtos;
using IMS.Core.Entities;

namespace IMS.Core.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            #region Customer
            CreateMap<CustomerDto, Customer>()
                    .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerDto>();
            #endregion

        }
    }
}
