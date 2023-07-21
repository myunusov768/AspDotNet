using AspCore;

public interface IDbRepository
{
    public Task<List<Todo>> GetAsync(CancellationToken token);
    public Task<List<Todo>> GetAsyncIsCompleted(CancellationToken token);
    public Task<List<Todo>> GetAsyncUnCompleted(CancellationToken token);

    public Task<bool> PutAsinc(int id,Todo todo, CancellationToken token);
    public Task<bool> DeleteAsync(int id, CancellationToken token);
    public Task<Todo> PostAsync(Todo todo, CancellationToken token);
    public Task<bool> DeletesAsync(int[] ids, CancellationToken token);
}