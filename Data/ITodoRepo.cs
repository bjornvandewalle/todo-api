using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Data {
    public interface ITodoRepo {
        bool SaveChanges();
        IEnumerable<TodoItem> GetAllTodoItems();   
        TodoItem GetTodoItem(int id);
        void CreateTodoItem(TodoItem tdi);
        void UpdateTodoItem(TodoItem tdi);
        void DeleteTodoItem(TodoItem tdi);
    }
}