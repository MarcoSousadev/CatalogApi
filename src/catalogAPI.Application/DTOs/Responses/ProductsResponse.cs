namespace catalogAPI.Application.DTOs.Responses
{
    public class ProductsResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
}
