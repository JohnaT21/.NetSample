using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace TestProject.Extensions
{
    public static class BackgroundServiceExtensions
    {
        // public static IServiceCollection AddBackgroundScheduleService(this IServiceCollection services, IConfiguration configuration)
        // {
        //
        //     services.AddSingleton<IJobFactory, SingletonJobFactory>();
        //     services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
        //
        //     services.AddSingleton<FacilityScheduleJob>();
        //     services.AddSingleton<WorkOrderCloserJob>();
        //     // services.AddSingleton<MfrOrgUnitJob>();
        //
        //     services.AddSingleton(new JobSchedule(
        //         jobType: typeof(FacilityScheduleJob),
        //         cronExpression: configuration.GetValue<string>("AutoSchedulerConfiguration:PreventiveAndInspectionCreatorJob.Cron")
        //     ));
        //
        //     services.AddSingleton(new JobSchedule(
        //         jobType: typeof(WorkOrderCloserJob),
        //         cronExpression: configuration.GetValue<string>("AutoSchedulerConfiguration:RequestCloserJob.Cron")
        //     ));
        //     // services.AddSingleton(new JobSchedule(
        //     //     jobType: typeof(MfrOrgUnitJob),
        //     //     cronExpression: configuration.GetValue<string>("AutoSchedulerConfiguration:MfrIntegration.Cron")
        //     // ));
        //
        //     services.AddHostedService<QuartzHostedService>();
        //
        //     return services;
        // }

        public static IApplicationBuilder UseCustomised(this IApplicationBuilder app)
        {
            // For symmetry, you may wish to still put this in an extension,
            // but you could also decide not to.
            //app.UsePolicy();

            return app;
        }
    }
}
