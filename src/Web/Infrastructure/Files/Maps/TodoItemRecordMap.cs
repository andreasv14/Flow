using System.Globalization;
using CsvHelper.Configuration;
using Flow.WebAPI.Application.TodoLists.Queries.ExportTodos;

namespace Flow.WebAPI.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
