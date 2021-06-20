﻿using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.Bootstrapper
{
    /// <summary>
    /// 
    /// </summary>
    public static class AutoMapperBootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddMapper(this IServiceCollection @this)
        {
            @this.AddAutoMapper(typeof(Startup));
            return @this;
        }
    }
}
