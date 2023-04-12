using Microsoft.Extensions.DependencyInjection;

namespace BootstrapBlazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBootstrapBlazor(this IServiceCollection services)
        {
            return services.AddBootstrapModal()
                .AddBootstrapToast();
        }

        public static IServiceCollection AddBootstrapModal(this IServiceCollection services) => services.AddScoped<ModalService>();

        public static IServiceCollection AddBootstrapToast(this IServiceCollection services) => services.AddScoped<ToastService>();
    }
}
