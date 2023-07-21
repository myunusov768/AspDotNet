using AspCore;
using Microsoft.EntityFrameworkCore;

public sealed class DbRepository : IDbRepository
{
    private readonly DbTodo _dbTodo;
    public DbRepository(DbTodo dbTodo)
    {
        ArgumentNullException.ThrowIfNull(dbTodo);
        _dbTodo = dbTodo;
    }
    public async Task<bool> DeleteAsync(int id, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(id);
        var getTodo = await _dbTodo.Todos.SingleAsync<Todo>(x=>x.Id == id,token);
        _dbTodo.Remove<Todo>(getTodo);
        return (await _dbTodo.SaveChangesAsync(token)) > 0;
    }

    public async Task<List<Todo>> GetAsync(CancellationToken token)
    {
        return await _dbTodo.Todos.ToListAsync<Todo>(token);
    }

    public async Task<Todo> PostAsync(Todo todo, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(todo);
        var result = await _dbTodo.AddAsync<Todo>(todo, token);
        return result.Entity;
    }

    public async Task<bool> PutAsinc(int id ,Todo todo, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(todo);
        ArgumentNullException.ThrowIfNull(id);
        var todoGet = await _dbTodo.Todos.SingleAsync<Todo>(x=>x.Id == id);
        todoGet.Name = todo.Name;
        todoGet.State = todo.State;
        return (await _dbTodo.SaveChangesAsync(token)) > 0;
    }
}
