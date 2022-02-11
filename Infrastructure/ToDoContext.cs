using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoApp_Project.Models;

namespace ToDoList.Infrastructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            :base(options)
        {
        }

        public DbSet<TodoList> ToDoList { get; set; }

        public DbSet<ToDoApp_Project.Models.User> User { get; set; }
    }
}
