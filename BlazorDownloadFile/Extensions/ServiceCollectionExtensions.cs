using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorDownloadFile
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers blazor download file service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorDownloadFile(this IServiceCollection services)
        {
            return services.AddSingleton((service) =>
            {
                var JSRuntime = service.GetRequiredService<IJSRuntime>();
                return new BlazorDownloadFileService(JSRuntime);
            });
        }
    }
}
