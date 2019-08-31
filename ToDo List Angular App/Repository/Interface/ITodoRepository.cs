using System.Collections.Generic;

public interface ITodoRepository
{
    List<Todo> GetAll();
    int Add(Todo todo);
    bool Update(int Id, Todo todo);
    bool Delete(int Id);
    bool MarkCompleted(int Id, bool IsCompleted);
} 