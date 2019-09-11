using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo_List_App.Model;

namespace ToDo_List_App.Service
{
    public class TodoService
    {
        private readonly ITodoRepository _repository;
        

        public TodoService(){}
        public TodoService(ITodoRepository repository)
        {
            this._repository = repository;
        }

        public Task<int> Add(Todo todo)
        {
            return  _repository.Add(todo);
        }

        public Task<bool> Delete(int Id)
        {
            return _repository.Delete(Id);
        }

        public Task<List<Todo>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<bool> MarkCompleted(int Id, bool IsCompleted)
        {
            return _repository.MarkCompleted(Id, IsCompleted);
        }

        public Task<bool> Update(int Id, Todo todo)
        {
            return _repository.Update(Id, todo);
        }
    }
}