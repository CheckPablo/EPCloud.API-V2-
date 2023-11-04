using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExamPortalApp.Daemon.BackgroundWorkers
{
    public class CreateStudentCredentialsBackgroundWorker : BackgroundService
    {
        private readonly ILogger<CreateStudentCredentialsBackgroundWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IBackgroundQueue<Tuple<int, int[]>> _queue;

        public CreateStudentCredentialsBackgroundWorker(ILogger<CreateStudentCredentialsBackgroundWorker> logger, IServiceScopeFactory scopeFactory,
            IBackgroundQueue<Tuple<int, int[]>> queue)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{Type} is now running in the background.", nameof(CreateStudentCredentialsBackgroundWorker));

            await BackgroundProcessing(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogCritical(
                "The {Type} is stopping due to a host shutdown, queued items might not be processed anymore.",
                nameof(CreateStudentCredentialsBackgroundWorker)
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

                    _logger.LogInformation("Students found to create credentials for!");

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetService<IStudentRepository>();

                        if (service != null) await service.CreateLoginCredentialsAsync(queued);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("An error occurred when adding a creating students' login credentials. Exception: {@Exception}", ex);
                }
            }
        }
    }
}
