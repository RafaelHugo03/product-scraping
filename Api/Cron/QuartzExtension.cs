using Quartz;

namespace Api.Cron
{
    public static class QuartzExtension
    {
        public static void AddJobAndTrigger<T>(
            this IServiceCollectionQuartzConfigurator quartz,
            IConfiguration config)
            where T : IJob
        {
            string nomeJob = typeof(T).Name;

            var configKey = $"Quartz:{nomeJob}";
            var runningTime = config[configKey]; 

            if (string.IsNullOrEmpty(runningTime))
            {
                throw new Exception($"No Quartz.NET Cron schedule found for job in configuration at {configKey}");
            }

            var jobKey = new JobKey(nomeJob);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(nomeJob + "-trigger")
                .WithCronSchedule(runningTime));
        }
    }
}
