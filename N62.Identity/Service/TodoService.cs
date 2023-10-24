using N62.Identity.Models.Entities;

namespace N62.Identity.Service;

public class TodoService
{
    public ValueTask<TodoTask> CreateAsync(TodoTask todoTask, Guid userId)
    {
        return new ValueTask<TodoTask>(todoTask);
    }
}