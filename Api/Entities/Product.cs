using Api.enums;

namespace Api.Entities
{
    public class Product : BaseEntity
    {
        public long? Code { get; set; }
        public string? BarCode { get; set; }
        public DateTime Imported_at { get; set; }
        public Status Status { get; set; }
        public string? Url { get; set; }
        public string? ProductName { get; set; }
        public string? Quantity { get; set; }
        public string? Categories { get; set; }
        public string? Packaging { get; set; }
        public string? Brands { get; set; }
        public string? ImageUrl { get; set; }

    }
}