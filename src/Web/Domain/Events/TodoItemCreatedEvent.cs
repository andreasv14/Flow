using Flow.WebAPI.Domain.Common;
using Flow.WebAPI.Domain.Entities;

namespace Flow.WebAPI.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
