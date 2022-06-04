using System.Globalization;
using CsvHelper;
using Flow.WebAPI.Application.Common.Interfaces;
using Flow.WebAPI.Application.TodoLists.Queries.ExportTodos;
using Flow.WebAPI.Infrastructure.Files.Maps;

namespace Flow.WebAPI.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
