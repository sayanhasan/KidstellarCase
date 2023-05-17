using KidstellarCase.Application.Repositories.UnitOfWork;
using KidstellarCase.Persistence.Contexts;
using KidstellarCase.Persistence.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KidstellarCase.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseMySql(Configuration.ConnectionString,ServerVersion.AutoDetect(Configuration.ConnectionString)));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
