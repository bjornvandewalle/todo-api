using System;
using System.Collections.Generic;
using TodoApi.Models;

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
                new TodoItem{ Id = 0, Name="Test", Description="This is just a test example", EnterdOn=DateTime.Now, finished = false, PriorityLevel = 3},
                new TodoItem{ Id = 1, Name="Random", Description="This is just something random", EnterdOn=DateTime.Now, finished = true, Endtime= DateTime.Now, PriorityLevel = 1},
                new TodoItem{ Id = 2, Name="Whatever", Description="We can fill in whatever we like", EnterdOn=DateTime.Now, finished = false, PriorityLevel = 5}
            };
        }

        public TodoItem GetTodoItem(int id)
        {
            return new TodoItem{ Id = 0, Name="Test", Description="This is just a test example", EnterdOn=DateTime.Now, finished = false, PriorityLevel = 3};
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