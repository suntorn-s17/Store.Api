using AutoMapper;
using Store.Api.DTOs.Requests;
using Store.Api.DTOs.Responses;
using Store.Api.Entities;

namespace Store.Api.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryRequestDto, Category>();

            CreateMap<Category, CategoryResponseDto>();
        }
    }
}