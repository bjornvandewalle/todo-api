using AutoMapper;
using TodoApi.Models;
using TodoApi.Dtos;

namespace TodoApi.Profiles
{
    public class TodoItemsProfile : Profile
    {
        public TodoItemsProfile()
        {
            //Source -> Target
            CreateMap<TodoItem, TodoItemReadDto>();
            CreateMap<TodoItemCreateDto, TodoItem>();
            CreateMap<TodoItemsUpdateDto, TodoItem>();
            CreateMap<TodoItem, TodoItemsUpdateDto>();
        }

    }
}