using AspCore;

public static class TodoExtension
{
    public static Todo ToTodo(this TodoDto todoDto)
    {
        ArgumentNullException.ThrowIfNull(todoDto);
        var newTodo = new Todo()
        {
            Id = todoDto.Id,
            Name = todoDto.Name,
            State = todoDto.State
        };
        return newTodo;
    }
}
