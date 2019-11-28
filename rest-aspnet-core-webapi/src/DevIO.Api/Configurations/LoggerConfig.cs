using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddElmahIo(o =>
            {
                o.ApiKey = "59264cfeccb9423cba5d9919aa4477c0";
                o.LogId = new Guid("1544f344-7b32-4d2d-bf31-cff2dc173c2c");
            });

            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "59264cfeccb9423cba5d9919aa4477c0";
            //        o.LogId = new Guid("1544f344-7b32-4d2d-bf31-cff2dc173c2c");
            //    });

            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Information);
            //});

            //services.AddHealthChecks()
            //    .AddElmahIoPublisher("388dd3a277cb44c4aa128b5c899a3106", new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096"),"API Fornecedores")
            //    .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
            //    .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            //services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            //app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
            //app.UseHealthChecksUI(options => { options.UIPath = "/api/hc-ui"; });

            return app;
        }
    }
}