using System;
using System.Collections.Generic;
using TodoApi.Models;
using TodoApi.Models.Enums;

namespace TodoApi.Data {
    public class MockTodoRepo : ITodoRepo
    {
        public void CreateTodoItem(TodoItem tdi)
        {
            throw new NotImplementedException();
        }

        public void DeleteTodoItem(TodoItem tdi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return new List<TodoItem> {
                new TodoItem{ Id = 0, Name="Test", Description="This is just a test example", CreationTime=DateTime.Now, finished = false, PriorityLevel = Priority.High},
                new TodoItem{ Id = 1, Name="Random", Description="This is just something random", CreationTime=DateTime.Now, finished = true, DueDate= DateTime.Now, PriorityLevel = Priority.Medium},
                new TodoItem{ Id = 2, Name="Whatever", Description="We can fill in whatever we like", CreationTime=DateTime.Now, finished = false, PriorityLevel = Priority.Low}
            };
        }

        public TodoItem GetTodoItem(int id)
        {
            return new TodoItem{ Id = 0, Name="Test", Description="This is just a test example", CreationTime=DateTime.Now, finished = false, PriorityLevel = Priority.Low};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTodoItem(TodoItem tdi)
        {
            throw new NotImplementedException();
        }
    }
}