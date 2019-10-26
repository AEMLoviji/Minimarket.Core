using AutoMapper;
using Minimarket.API.Domain.Models;
using Minimarket.API.ViewModels;
using Minimarket.API.Extensions;

namespace Minimarket.API.Mappers
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>()
               .ForMember(src => src.UnitOfMeasurement,
                          opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}