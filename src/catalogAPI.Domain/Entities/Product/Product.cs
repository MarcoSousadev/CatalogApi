namespace catalogAPI.Domain.Entities.Product
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; }

        public bool IsActive { get; set; }

    }
}
