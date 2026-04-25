using catalogAPI.Application.Interfaces;
using catalogAPI.Application.UseCases.Categories;
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
      
        }
    }
}
