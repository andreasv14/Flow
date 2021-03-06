using Flow.WebAPI.Domain.Common;
using Flow.WebAPI.Domain.Entities;

namespace Flow.WebAPI.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
