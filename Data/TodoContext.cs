using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoContext : DbContext 
    {
        public TodoContext(DbContextOptions<TodoContext> opt) : base(opt) {}

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}