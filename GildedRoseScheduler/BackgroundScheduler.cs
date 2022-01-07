using GildedRoseKata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NCrontab;

namespace GildedRoseScheduler
{
    internal class BackgroundScheduler : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;

        private readonly CrontabSchedule schedule;

        public BackgroundScheduler(IServiceProvider serviceProvider,
            IOptions<SchedulerSettings> schedulerSettings)
        {
            this.serviceProvider = serviceProvider;
            this.schedule = CrontabSchedule.Parse(schedulerSettings.Value.QualityUpdateSchedule);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = serviceProvider.CreateScope();
                var gildedRose = scope.ServiceProvider.GetRequiredService<GildedRose>();
                gildedRose.UpdateQuality();

                await Task.Delay(50000, stoppingToken);
            }
        }
    }
}
