using AutoMapper;
using TodoApi.Domain.Entities;
using TodoApi.Domain.ViewModels.TodoViewModels;

namespace TodoApi.Application.Configurations.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<Todo, TodoInputModel>().ReverseMap();
    }
}
