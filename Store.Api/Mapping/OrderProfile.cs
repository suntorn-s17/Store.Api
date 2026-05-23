using AutoMapper;
using Store.Api.DTOs.Requests;
using Store.Api.DTOs.Responses;
using Store.Api.Entities;

namespace Store.Api.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDetailDto, OrderDetail>();

            CreateMap<CreateOrderRequestDto, Order>();

            CreateMap<OrderDetail, OrderDetailResponseDto>();

            CreateMap<Order, OrderResponseDto>();

            CreateMap<UpdateOrderDetailDto, OrderDetail>();

            CreateMap<UpdateOrderRequestDto, Order>();
        }
    }
}