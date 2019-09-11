using Microsoft.EntityFrameworkCore;
using ToDo_List_App.Model;

public class TodoDbContext: DbContext
{
    public TodoDbContext() {}

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {}

    public DbSet<Todo> Todos {get; set;}

}