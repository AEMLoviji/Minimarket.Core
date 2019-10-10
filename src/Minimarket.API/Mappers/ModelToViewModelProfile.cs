using AutoMapper;
using Minimarket.API.Domain.Models;
using Minimarket.API.ViewModels;

namespace Minimarket.API.Mappers
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}