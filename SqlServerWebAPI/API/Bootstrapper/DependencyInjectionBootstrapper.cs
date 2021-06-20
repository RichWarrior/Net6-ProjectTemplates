using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace $safeprojectname$.Bootstrapper
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjectionBootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection @this)
        {
            @this.AddScoped<IUnitOfWork, UnitOfWork>();
            @this.AddScoped<IDbContext, DbContext>();
            return @this;
        }
    }
}
