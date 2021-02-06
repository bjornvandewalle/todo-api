using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApi.Data;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Controllers {

    //api/TodoItems
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase {
        private readonly ITodoRepo _repository;
        private readonly IMapper _mapper;

        public TodoItemsController(ITodoRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/todoitems
        [HttpGet]
        public ActionResult<IEnumerable<TodoItemReadDto>> GetAllTodoItems() {
            var todoItems = _repository.GetAllTodoItems();

            return Ok(_mapper.Map<IEnumerable<TodoItemReadDto>>(todoItems));
        } 

        //GET api/todoitems/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItemReadDto> GetTodoItemById(int id) {
            var todoItem = _repository.GetTodoItem(id);

            if (todoItem != null ) return Ok(_mapper.Map<TodoItemReadDto>(todoItem));
            return NotFound();
        }

        //Post api/todoitems
        [HttpPost]
        public ActionResult<TodoItemReadDto> CreateTodoItem(TodoItemCreateDto todoItemDto) {
            var todoItem = _mapper.Map<TodoItem>(todoItemDto);

            _repository.CreateTodoItem(todoItem);
            _repository.SaveChanges();

            var todoItemReadDto = _mapper.Map<TodoItemReadDto>(todoItem);

            return CreatedAtRoute(nameof(GetTodoItemById), new {Id = todoItemReadDto.Id}, todoItemReadDto);
        }

        //PUT api/todoitems/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(int id, TodoItemsUpdateDto todoItemsUpdateDto) {
            var todoItemModelFromRepo = _repository.GetTodoItem(id);
            if (todoItemModelFromRepo == null) return NotFound();

            _mapper.Map(todoItemsUpdateDto, todoItemModelFromRepo);
            _repository.UpdateTodoItem(todoItemModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


        //PATCH api/todoitems/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTodoItemUpdate(int id, JsonPatchDocument<TodoItemsUpdateDto> patchDoc) {
            var todoItemModelFromRepo = _repository.GetTodoItem(id);
            if(todoItemModelFromRepo == null) return NotFound();

            var todoItemToPatch = _mapper.Map<TodoItemsUpdateDto>(todoItemModelFromRepo);
            patchDoc.ApplyTo(todoItemToPatch, ModelState);

            if (!TryValidateModel(todoItemToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(todoItemToPatch, todoItemModelFromRepo);
            _repository.UpdateTodoItem(todoItemModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/todoitems/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(int id) {
            var todoItemModelFromRepo = _repository.GetTodoItem(id);
            if(todoItemModelFromRepo == null) return NotFound();

            _repository.DeleteTodoItem(todoItemModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}