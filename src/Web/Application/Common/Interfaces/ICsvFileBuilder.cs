using Flow.WebAPI.Application.TodoLists.Queries.ExportTodos;

namespace Flow.WebAPI.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
