using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
public class TodoRepository : ITodoRepository, IDisposable
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        this._context = context;
    }

    public async Task<List<Todo>> GetAll()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<int> Add(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo.Id;
    }

    public Task<Todo> Find(int Id)
    {
        return  _context.Todos.FindAsync(Id);
    }

    public async Task<bool> Update(int Id, Todo newTodo)
    {
        var todo = await Find(Id);
         todo.WorkTodo = newTodo.WorkTodo;
         todo.IsCompleted = newTodo.IsCompleted;
         todo.CreatedOn = DateTime.Now;
         await _context.SaveChangesAsync();
         return true;
    }

    public async Task<bool> Delete(int Id)
    {
       var todo = await Find(Id);
        _context.Remove(todo);
       await _context.SaveChangesAsync();
       return true;
    }

    
    public async Task<bool> MarkCompleted(int Id, bool IsCompleted)
    {
         var todo = await Find(Id);
         todo.IsCompleted = IsCompleted;
         await _context.SaveChangesAsync();
         return true;
    }

    #region Dispose method
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion

 
}