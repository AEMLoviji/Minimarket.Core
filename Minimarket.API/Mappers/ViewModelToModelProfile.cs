using AutoMapper;
using Minimarket.API.Domain.Models;
using Minimarket.API.ViewModels;

namespace Minimarket.API.Mappers
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<SaveCategoryViewModel, Category>();
        }
    }
}