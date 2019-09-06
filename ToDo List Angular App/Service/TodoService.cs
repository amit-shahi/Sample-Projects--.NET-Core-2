using System.Collections.Generic;
using System.Threading.Tasks;

public class TodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        this._repository = repository;
    }

    public async Task<int> Add(Todo todo)
    {
        return await _repository.Add(todo).ConfigureAwait(false);
    }

    public async Task<bool> Delete(int Id)
    {
        return await _repository.Delete(Id).ConfigureAwait(false);
    }

    public async Task<List<Todo>> GetAll()
    {
       return await _repository.GetAll().ConfigureAwait(false);
    }

    public async Task<bool> MarkCompleted(int Id, bool IsCompleted)
    {
       return await _repository.MarkCompleted(Id, IsCompleted).ConfigureAwait(false);
    }

    public async Task<bool> Update(int Id, Todo todo)
    {
        return await _repository.Update(Id, todo).ConfigureAwait(false);
    }

}