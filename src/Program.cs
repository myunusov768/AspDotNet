using System.Net;
using Microsoft.EntityFrameworkCore;
using AspCore;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSingleton<ITodoService, TodoService>((service) =>
{
    var db = new DbTodo();
    var _dbRepository = new DbRepository(db);
    var _todoService = new TodoService(_dbRepository);
    return _todoService;
});


var app = builder.Build();

app.MapGroup("/todos");

app.MapGet("",async (ITodoService todoService,CancellationToken token) =>  
{
    return (await todoService.GetAsync(token));
});
app.MapGet("/completed",async (ITodoService todoService,CancellationToken token) =>  
{
    return (await todoService.GetAsyncIsCompleted(token));
});
app.MapGet("/uncompleted",async (ITodoService todoService,CancellationToken token) =>  
{
    return (await todoService.GetAsyncUnCompleted(token));
});
app.MapPost("", async (ITodoService todoService,TodoDto todoDto ,CancellationToken token) => 
{
    ArgumentNullException.ThrowIfNull(todoDto);
    return await todoService.PostAsync(todoDto,token);
});

app.MapPut("/{id}",async (ITodoService todoService,int id,TodoDto todoDto, CancellationToken token) => 
{
    ArgumentNullException.ThrowIfNull(todoDto);
    return await todoService.PutAsinc(id,todoDto, token);
});
app.MapDelete("/{id}",async (ITodoService todoService,int id, CancellationToken token) => 
{
    ArgumentNullException.ThrowIfNull(id);
    return await todoService.DeleteAsync(id, token);
});


app.Run();
