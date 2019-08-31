using System.Collections.Generic;

public class TodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        this._repository = repository;
    }

    public int Add(Todo todo)
    {
        return _repository.Add(todo);
    }

    public bool Delete(int Id)
    {
        return _repository.Delete(Id);
    }

    public List<Todo> GetAll()
    {
       return  _repository.GetAll();
    }

    public bool MarkCompleted(int Id, bool IsCompleted)
    {
       return _repository.MarkCompleted(Id, IsCompleted);
    }

    public bool Update(int Id, Todo todo)
    {
        return _repository.Update(Id, todo);
    }

}