using Audi.DAL.Context;
using Audi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Audi.DAL
{
    public static class AudiDALExtention
    {
        public static void AddAudiDAL(this IServiceCollection services, string conString)
        {
            services.AddDbContext<AudiContext>(options =>
                   options.UseSqlServer(conString));

            services.AddTransient<IAudiRepository, AudiRepository>();
        }
    }
}
