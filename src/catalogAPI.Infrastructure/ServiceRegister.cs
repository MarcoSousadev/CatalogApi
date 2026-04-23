using Microsoft.Extensions.DependencyInjection;

namespace catalogAPI.Infrastructure
{
    
        public static class ServiceRegister
        {
            public static void AddInfraestructure(this IServiceCollection services)
            {
                AddRepositories(services);
            }

            public static void AddRepositories (IServiceCollection services)
            {

            }
        }
 }

