using AutoMapper;
using Store.Api.DTOs.Requests;
using Store.Api.DTOs.Responses;
using Store.Api.Entities;

namespace Store.Api.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequestDto, Customer>();

            CreateMap<Customer, CustomerResponseDto>();

            CreateMap<UpdateCustomerRequestDto, Customer>();
        }
    }
}