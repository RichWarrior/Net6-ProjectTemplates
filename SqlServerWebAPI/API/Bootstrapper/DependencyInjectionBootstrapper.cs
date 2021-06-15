using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace API.Bootstrapper
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
            return @this;
        }
    }
}
