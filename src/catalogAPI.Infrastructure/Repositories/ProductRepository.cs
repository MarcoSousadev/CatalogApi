using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.Interfaces.Repositories;
using catalogAPI.Domain.Entities.Product;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace catalogAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _dbConnection;

        public ProductRepository(IConfiguration configuration)
        {
            _dbConnection = configuration.GetConnectionString(_dbConnection) ?? throw new InvalidOperationException("Connection string not found");
        }
        public async Task CreateProduct(ProductsRequest request)
        {
            using var connection = new SqlConnection(_dbConnection);

            var query = "INSERT INTO Products (Name, Description, Price, CategoryId) VALUES(@Name, @Description, @Price, @CategoryId) ";

            await connection.QueryAsync(query, new { Name = request.Name, Description = request.Description, Price = request.Price, CategoryId = request.CategoryId, });
        }

        public async Task Delete(int id)
        {
            using var connection = new SqlConnection(_dbConnection);

            var query = "DELETE * FROM Products WHERE Id=@Id";

            await connection.QueryAsync(query, new {Id = id });
        }

        public async Task<IEnumerable<Product>> GetAllItensWithPagination(int pageNumber, int pageQuantity)
        {
            using var connection = new SqlConnection(_dbConnection); 

            var skip = (pageNumber - 1) * pageQuantity;

            var query = "SELECT * FROM Products OFFSET @Skip ROWS FETCH NEXT @Quantity ROWS ONLY ";

            return await connection.QueryAsync<Product>(query, new { Skip = skip, Quantity = pageQuantity });

        }

        public async Task<Product> GetById(int id)
        {
            using var connection = new SqlConnection(_dbConnection);

            var query = "SELECT * FROM Products WHERE Id = @Id";

            return (Product)await connection.QueryAsync<Product>(query, new { Id = id });
        }

        public async Task Update(int id, ProductsRequest request)
        {
            using var connection = new SqlConnection(_dbConnection);

            var query = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, CategoryId = @CategoryId Where Id = @Id ";

            await connection.QueryAsync(query, new { Name = request.Name, Description = request.Description, Price = request.Price, CategoryId = request.CategoryId });
        }
    }
}
