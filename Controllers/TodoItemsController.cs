using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Models.Dto;

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
        public ActionResult<IEnumerable<TodoReadDto>> GetAllTodoItems() {
            var todoItems = _repository.GetAllTodoItems();

            return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(todoItems));
        } 

        //GET api/todoitems/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoReadDto> GetTodoItemById(int id) {
            var todoItem = _repository.GetTodoItem(id);

            return todoItem != null ? Ok(_mapper.Map<TodoReadDto>(todoItem)) : NotFound();
        }

        //Post api/todoitems
        [HttpPost]
        public ActionResult<TodoReadDto> CreateTodoItem(TodoCreateDto todoCreateDto) {
            var todo = _mapper.Map<TodoItem>(todoCreateDto);
            
            _repository.CreateTodoItem(todo);
            _repository.SaveChanges();

            var todoReadDto = _mapper.Map<TodoReadDto>(todo);

            return CreatedAtAction(nameof(GetTodoItemById), new {id = todoReadDto.Id}, todoReadDto);
        }

        //PUT api/todoitems/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(int id, TodoUpdateDto todoUpdateDto) {
            var todoItemModelFromRepo = _repository.GetTodoItem(id);
            if (todoItemModelFromRepo == null) return NotFound();

            _mapper.Map(todoUpdateDto, todoItemModelFromRepo);

            _repository.UpdateTodoItem(todoItemModelFromRepo);
            var result = _repository.SaveChanges();

            return NoContent();
        }


        //PATCH api/todoitems/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTodoItemUpdate(int id, JsonPatchDocument<TodoUpdateDto> patchDoc) {
            var todoItemModelFromRepo = _repository.GetTodoItem(id);
            if(todoItemModelFromRepo == null) return NotFound();

            var TodoToPatch = _mapper.Map<TodoUpdateDto>(todoItemModelFromRepo);
            patchDoc.ApplyTo(TodoToPatch, ModelState);

            if (!TryValidateModel(TodoToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(TodoToPatch, todoItemModelFromRepo);    
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