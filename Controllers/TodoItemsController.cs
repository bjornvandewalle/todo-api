using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers {

    //api/TodoItems
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase {
        private readonly ITodoRepo _repository;

        public TodoItemsController(ITodoRepo repository) {
            _repository = repository;
        }
        
        //GET api/todoitems
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAllTodoItems() {
            var todoItems = _repository.GetAllTodoItems();
            return Ok(todoItems);
        } 

        //GET api/todoitems/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(int id) {
            var todoItem = _repository.GetTodoItem(id);
            return todoItem != null ? Ok(todoItem) : NotFound();
        }

        //Post api/todoitems
        [HttpPost]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem) {
            _repository.CreateTodoItem(todoItem);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetTodoItemById), new {Id = todoItem.Id}, todoItem);
        }

        //PUT api/todoitems/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(int id, TodoItem todoItem) {
            var todoItemModelFromRepo = _repository.GetTodoItem(id);
            if (todoItemModelFromRepo == null) return NotFound();

            todoItemModelFromRepo = todoItem;

            _repository.UpdateTodoItem(todoItemModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


        //PATCH api/todoitems/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTodoItemUpdate(int id, JsonPatchDocument<TodoItem> patchDoc) {
            var todoItemModelFromRepo = _repository.GetTodoItem(id);
            if(todoItemModelFromRepo == null) return NotFound();

            patchDoc.ApplyTo(todoItemModelFromRepo, ModelState);

            if (!TryValidateModel(todoItemModelFromRepo)) return ValidationProblem(ModelState);

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