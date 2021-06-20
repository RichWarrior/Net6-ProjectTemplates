using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Bootstrapper
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerBootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        private static bool IsDevelopment => Environment.Environment.Instance.IsDevelopment;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection @this)
        {
            if (IsDevelopment)
            {
                @this.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Swagger Title",
                        Version = "v1"
                    });
                });
            }

            return @this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerGen(this IApplicationBuilder @this)
        {
            if (IsDevelopment)
            {
                @this.UseSwagger();
                @this.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Title"));
            }
            return @this;
        }

    }
}
