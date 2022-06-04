using Flow.WebAPI.Application.Common.Mappings;
using Flow.WebAPI.Domain.Entities;

namespace Flow.WebAPI.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
