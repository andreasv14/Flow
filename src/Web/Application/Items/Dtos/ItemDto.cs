namespace Flow.WebAPI.Application.Items.Dtos;

public record ItemDto
{
    public Guid ItemId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
