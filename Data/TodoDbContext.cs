using Microsoft.EntityFrameworkCore;
using ToDo_App.Models;

namespace ToDo_App.Data
{
    public class TodoDbContext : DbContext
    {
        
            public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
            {

            }

            public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }


    }

