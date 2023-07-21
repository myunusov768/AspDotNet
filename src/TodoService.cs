using AspCore;

public sealed class TodoService : ITodoService
{
    private readonly IDbRepository _repository;
    public TodoService(IDbRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(id);
        return await _repository.DeleteAsync(id, token);
    }

    public async Task<List<TodoDto>> GetAsync(CancellationToken token)
    {
        return (await _repository.GetAsync(token)).ToTodoDto();
    }

    public async Task<TodoDto> PostAsync(TodoDto todoDto, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(todoDto);
        return (await _repository.PostAsync(todoDto.ToTodo(),token)).ToTodoDto();
    }

    public async Task<bool> PutAsinc(int id ,TodoDto todoDto, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(todoDto);
        ArgumentNullException.ThrowIfNull(id);
        return await _repository.PutAsinc(id,todoDto.ToTodo(),token);
    }
}
