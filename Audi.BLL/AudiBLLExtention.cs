using Audi.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Audi.BLL
{
    public static class AudiBLLExtention
    {
        public static void AddAudiBLL(this IServiceCollection services)
        {
            services.AddTransient<IAudiService, AudiService>();
        }
    }
}