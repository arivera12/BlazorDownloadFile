using Microsoft.Extensions.DependencyInjection;

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
            return services.AddScoped<IBlazorDownloadFileService, BlazorDownloadFileService>();
        }
    }
}
