using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace $safeprojectname$.Bootstrapper
{
    /// <summary>
    /// 
    /// </summary>
    public static class LocalizationBootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddLocalizationMessage(this IServiceCollection @this)
        {
            @this.AddLocalization(options =>
            {
                options.ResourcesPath = "";
            });
            return @this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLocalizationMessage(this IApplicationBuilder @this)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("tr")
            };


            @this.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            return @this;
        }
    }
}
