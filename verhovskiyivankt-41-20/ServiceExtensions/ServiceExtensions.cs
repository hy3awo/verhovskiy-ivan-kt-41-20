using VerhovskiyIvanKT_41_20.Interfaces.GroupsInterfaces;
namespace VerhovskiyIvanKT_41_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGroupService, GroupService>();
            return services;
        }
    }
}
