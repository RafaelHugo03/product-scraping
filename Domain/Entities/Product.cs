using Domain.enums;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public long Code { get; private set; }
        public string BarCode { get; private set; }
        public DateTime Imported_at { get; private set; }
        public Status Status { get; private set; }
        public string Url { get; private set; }
        public string ProductName { get; private set; }
        public string Quantity { get; private set; }
        public string Categories { get; private set; }
        public string Packaging { get; private set; }
        public string Brands { get; private set; }
        public string ImageUrl { get; private set; }

        public Product(long code, 
            string barCode,
            DateTime imported_at, 
            Status status,
            string url, 
            string productName, 
            string quantity, 
            string categories, 
            string packaging, 
            string brands, 
            string imageUrl)
        {
            Code = code;
            BarCode = barCode;
            Imported_at = imported_at;
            Status = status;
            Url = url;
            ProductName = productName;
            Quantity = quantity;
            Categories = categories;
            Packaging = packaging;
            Brands = brands;
            ImageUrl = imageUrl;
        }
    }
}