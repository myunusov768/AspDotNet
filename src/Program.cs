using Microsoft.EntityFrameworkCore;
using AspCore;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var db = new DbTodo();

var _dbRepository = new DbRepository(db);
var _todoService = new TodoService(_dbRepository);

app.MapGet("/todos",async (CancellationToken token) =>  
{
    return (await _todoService.GetAsync(token));
});
app.MapPost("/todos", async (TodoDto todoDto ,CancellationToken token) => 
{
    ArgumentNullException.ThrowIfNull(todoDto);
    return await _todoService.PostAsync(todoDto,token);
});

app.MapPut("/todos/{id}",async (DbTodo db,int id,TodoDto todoDto, CancellationToken token) => 
{
    ArgumentNullException.ThrowIfNull(todoDto);
    return await _todoService.PutAsinc(id,todoDto, token);
});
app.MapDelete("/todos/{id}",async (DbTodo db,int id, CancellationToken token) => 
{
    ArgumentNullException.ThrowIfNull(id);
    return await _todoService.DeleteAsync(id, token);
});

app.Run();
