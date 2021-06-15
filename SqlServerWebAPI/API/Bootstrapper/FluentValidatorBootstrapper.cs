using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Bootstrapper
{
    /// <summary>
    /// 
    /// </summary>
    public static class FluentValidatorBootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IMvcBuilder AddFluentValidatorBootstrapper(this IMvcBuilder @this)
        {
            @this.AddFluentValidation(fv =>
            {
                //fv.RegisterValidatorsFromAssemblyContaining(typeof(T))
            });
            return @this;
        }
    }
}
