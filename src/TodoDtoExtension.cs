using AspCore;

public static class TodoDtoExtension
{
    public static TodoDto ToTodoDto(this Todo todo)
    {
        ArgumentNullException.ThrowIfNull(todo);
        var newTodoDto = new TodoDto()
        {
            Id = todo.Id,
            Name = todo.Name,
            State = todo.State
        };
        return newTodoDto;
    }
    public static List<TodoDto> ToTodoDto(this IList<Todo> todos)
    {
        ArgumentNullException.ThrowIfNull(todos);
        var todoDtos = new List<TodoDto>();
        foreach(var todoDto in todos)
            todoDtos.Add(todoDto.ToTodoDto());
        return todoDtos;
    }
}