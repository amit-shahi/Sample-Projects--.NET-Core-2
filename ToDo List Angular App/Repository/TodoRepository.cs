using System.Collections.Generic;
using System.Linq;
using System;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        this._context = context;
    }

    public List<Todo> GetAll()
    {
        return _context.Todos.ToList();
    }

    public int Add(Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
        return todo.Id;
    }

    public bool Update(int Id, Todo newTodo)
    {
        var todo =  _context.Todos.Find(Id);
         todo.WorkTodo = newTodo.WorkTodo;
         todo.IsCompleted = newTodo.IsCompleted;
         todo.CreatedOn = DateTime.Now;
         _context.SaveChanges();
         return true;
    }

    public bool Delete(int Id)
    {
       var todo =  _context.Todos.Find(Id);
       _context.Remove(todo);
       _context.SaveChanges();
       return true;
    }

    
    public bool MarkCompleted(int Id, bool IsCompleted)
    {
         var todo =  _context.Todos.Find(Id);
         todo.IsCompleted = IsCompleted;
         _context.SaveChanges();
         return true;
    }

 
}