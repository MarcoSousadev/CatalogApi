using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.Interfaces.Repositories;
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


    }
}
