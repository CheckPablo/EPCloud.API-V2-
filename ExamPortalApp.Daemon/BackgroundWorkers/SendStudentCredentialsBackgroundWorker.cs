using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExamPortalApp.Daemon.BackgroundWorkers
{
    public class SendStudentCredentialsBackgroundWorker : BackgroundService
    {
        private readonly ILogger<SendStudentCredentialsBackgroundWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IBackgroundQueue<Dictionary<int, int[]>> _queue;

        public SendStudentCredentialsBackgroundWorker(ILogger<SendStudentCredentialsBackgroundWorker> logger, IServiceScopeFactory scopeFactory,
            IBackgroundQueue<Dictionary<int, int[]>> queue)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{Type} is now running in the background.", nameof(SendStudentCredentialsBackgroundWorker));

            await BackgroundProcessing(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogCritical(
                "The {Type} is stopping due to a host shutdown, queued items might not be processed anymore.",
                nameof(SendStudentCredentialsBackgroundWorker)
            );

            return base.StopAsync(cancellationToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(5 * 1000, stoppingToken);

                    var queued = _queue.Dequeue();

                    if (queued is null) continue;

                    _logger.LogInformation("{0} students found! Sending...", queued.Count);

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetService<IStudentRepository>();

                        if (service != null) await service.SendLoginCredentialsAsync(queued);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("An error occurred when adding a sending students' login credentials. Exception: {@Exception}", ex);
                }
            }
        }
    }
}
