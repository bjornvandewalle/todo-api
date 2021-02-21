using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data 
{
    public class SqlTodoRepo : ITodoRepo
    {
        private readonly TodoContext _context;

        public SqlTodoRepo(TodoContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem GetTodoItem(int id)
        {
            return _context.TodoItems.FirstOrDefault(ti => ti.Id == id);
        }
        public void CreateTodoItem(TodoItem tdi)
        {
            if(tdi == null) throw new ArgumentNullException(nameof(tdi));

            _context.TodoItems.Add(tdi);
        }

        public void UpdateTodoItem(TodoItem tdi)
        {
            // Not Needed
        }

        public void DeleteTodoItem(TodoItem tdi)
        {
            if(tdi == null) throw new ArgumentNullException(nameof(tdi));

            _context.TodoItems.Remove(tdi);
        }
    }
}