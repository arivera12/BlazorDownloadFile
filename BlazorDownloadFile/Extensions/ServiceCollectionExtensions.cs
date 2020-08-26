using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;

namespace BlazorDownloadFile
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers blazor download file service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorDownloadFile(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            return ServiceCollectionDescriptorExtensions.Add(services, 
                new ServiceDescriptor(typeof(IBlazorDownloadFileService), 
                sp => new BlazorDownloadFileService(sp.GetRequiredService<IJSRuntime>()), 
                lifetime));
        }
    }
}
