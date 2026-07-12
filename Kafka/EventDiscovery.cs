using catalogAPI.Domain.EventsConfig;
using System.Reflection;

namespace catalogAPI.Kafka
{
    public static class EventDiscovery
    {
        public static IReadOnlyCollection<Type> FindEvents(params Assembly[] assemblies)
        {
            return assemblies.SelectMany(GetLoadableTypes)
                .Where(type => type.IsClass &&
                    !type.IsAbstract &&
                    typeof(IntegrationEvent).IsAssignableFrom(type) &&
                    type.GetCustomAttribute<MessageTopicAttribute>() is not null)
                .ToArray();
        }

        private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }catch(ReflectionTypeLoadException exception)
            {
                return exception.Types.Where(type => type is not null).Cast<Type>();
            }

        }
    }
}
