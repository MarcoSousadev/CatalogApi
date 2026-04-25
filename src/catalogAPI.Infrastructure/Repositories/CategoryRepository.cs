using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.DTOs.Responses;
using catalogAPI.Application.Interfaces.Repository;
using catalogAPI.Domain.Entities.Category;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace catalogAPI.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepository(IConfiguration configuration)
        {
          
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found"); 
        }

        public async Task<Category> CreateCategoryAsync(CategoryRequest category)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Categories (Name, Description) OUTPUT INSERTED.* VALUES(@Name, @Description)";

            return await connection.QuerySingleAsync<Category>(query, new { Name = category.Name, Description = category.Description });
        }

        
        public async Task<Category> GetCategoryAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "SELECT * FROM Categories WHERE Id = @Id";

            return (Category)await connection.QueryAsync<Category>(query, new { Id = id });
        }

        public async Task DeleteCategory(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE * FROM Categories WHERE Id = @Id";

            await connection.QueryAsync<Category>(query, new { Id = id });
        }

        public async Task<IEnumerable<Category>> GetAllItensPaginatedAsync(int pageNumber, int pageQuantity)
        {
            using var connection = new SqlConnection(_connectionString);

            var jump = (pageNumber - 1) * pageQuantity;

            var query = "SELECT * FROM Categories OFFSET @Jump ROWS FETCH NEXT @Quantity ROWS ONLY";

            return await connection.QueryAsync<Category>(query, new { Jump = jump, Quantity = pageQuantity });
        }


        public async Task UpdateCategory(int id, CategoryRequest request)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "UPDATE Categories SET Name = @Name, Description = @Description WHERE Id = @Id ";

            await connection.QueryFirstOrDefaultAsync<Category>(query, new { Name = request.Name, Description = request.Description, Id = id });

        }
    }
}
