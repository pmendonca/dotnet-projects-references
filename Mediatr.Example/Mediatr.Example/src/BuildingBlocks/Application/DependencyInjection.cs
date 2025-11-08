using FluentValidation;
using Mediatr.Example.src.BuildingBlocks.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mediatr.Example.src.BuildingBlocks.Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, params Type[] markerTypes)
        {
            var assemblies = markerTypes.Select(t => t.Assembly).Distinct().ToArray();

            services.AddMediatR(cfg => {
                    cfg.RegisterServicesFromAssemblies(assemblies);
                    cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzkwMTIxNjAwIiwiaWF0IjoiMTc1ODY0Njg5MSIsImFjY291bnRfaWQiOiIwMTk5Nzc4NTFjYjY3NjgwOGM3Y2Y3ZTI0ZWVjMGEzMSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazV2cmJ3dGp3bnR6YXhubW1xanM5ZnZ4Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.ZhsmMH0FY6r39Lhgv_MbgMWOvKo_MOmiPqUqU1YlwaqBMHEXFSmOl2HJ21O0L_NdickvsvPt3z0MIOoPvN8UCI12nUZo46MEU0y1MdYweq3-zoerO8RR8GxQobCf6Xm958MZMbXs88vrktfgsNvGHM5k0uTzL2LA2Tn4L7hDXMm4zagvIJICjpwJXBCbAmZknb8bBq6FMQIRf_dv3A57KthjxmTz8itnWt6x2df_9sNvchQk1E6pGzTdsmDqzKdgdvIuPIhlqKeoLTqVp9o_sMeFGu_DdXlvZ72Pwm2NFSeYMDG8-hTpO294XSkL43bAS-0aPqFuFVH3BAwNdxfHLQ";
                });
            
            services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: false);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

            Modules.Orders.Infrastructure.DependencyInjection.OrdersDI(services);

            return services;
        }
    }
}
