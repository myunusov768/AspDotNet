using AspCore;

public interface ITodoService
{
    public Task<List<TodoDto>> GetAsync(CancellationToken token);
    public Task<List<Todo>> GetAsyncIsCompleted(CancellationToken token);
    public Task<List<Todo>> GetAsyncUnCompleted(CancellationToken token);
    public Task<bool> PutAsinc(int id ,TodoDto todoDto, CancellationToken token);
    public Task<bool> DeleteAsync(int id, CancellationToken token);
    public Task<TodoDto> PostAsync(TodoDto todoDto, CancellationToken token);
    public Task<bool> DeletesAsync(int[] ids, CancellationToken token);
}
