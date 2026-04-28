using catalogAPI.Application.Interfaces.UseCases.Categories;
using catalogAPI.Application.Interfaces.UseCases.Products;
using catalogAPI.Application.UseCases.Categories;
using catalogAPI.Application.UseCases.Products;
using Microsoft.Extensions.DependencyInjection;

namespace catalogAPI.Application
{
    public static class ServiceRegister
    {
        public static void AddAplication(this IServiceCollection services) 
        {
            AddUseCases(services);
        }

        public static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
            services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            services.AddScoped<IListAllItensUseCase, ListAllItensUseCase>();
            services.AddScoped<IRemoveCategoryUseCase, RemoveCategoryUseCase>();

            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IGetProcutByIdUseCase, GetProductByIdUseCase>();
            services.AddScoped<IDeleteProductUseCase,DeleteProductUseCase>();
            services.AddScoped<IListAllItensPaginatedUseCase, ListAllItensPaginateUseCase>();
            services.AddScoped<IUpdateCategoryUseCase, IUpdateCategoryUseCase>();

        }
    }
}
