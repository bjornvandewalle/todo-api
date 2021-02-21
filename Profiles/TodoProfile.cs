using AutoMapper;
using TodoApi.Models;
using TodoApi.Models.Dto;

namespace TodoApi.Profiles {
    public class TodoProfile : Profile {
        
        public TodoProfile() {
            CreateMap<TodoItem, TodoReadDto>();
            CreateMap<TodoCreateDto, TodoItem>();
            CreateMap<TodoUpdateDto, TodoItem>();
            CreateMap<TodoItem, TodoUpdateDto>();
        }
    }
}