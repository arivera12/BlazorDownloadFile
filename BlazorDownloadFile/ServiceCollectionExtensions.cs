using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorDownloadFile
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorDownloadFile(this IServiceCollection services)
        {
            return services.AddSingleton((service) =>
            {
                var JSRuntime = service.GetRequiredService<IJSRuntime>();
                return new BlazorDownloadFile(JSRuntime);
            });
        }
    }
}
