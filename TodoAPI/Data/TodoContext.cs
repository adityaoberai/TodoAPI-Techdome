using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            LoadTodoItems();
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public void LoadTodoItems()
        {
            var todoitems = new List<TodoItem>
            {
                new TodoItem()
                {
                    Id = 1,
                    TaskToDo = "Task 1"
                },

                new TodoItem()
                {
                    Id = 2,
                    TaskToDo = "Task 2"
                }
            };
            TodoItems.AddRange(todoitems);
            SaveChanges();
        }
    }
}
