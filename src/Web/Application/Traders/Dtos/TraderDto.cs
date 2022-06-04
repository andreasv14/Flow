namespace Flow.WebAPI.Application.Traders.Dtos
{
    public class TraderDto
    {
        public Guid TraderId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCustomer { get; set; }

        public bool IsSupplier { get; set; }
    }
}