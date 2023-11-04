using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExamPortalApp.Daemon.BackgroundWorkers
{
    public class EmailSenderBackgroundWorker : BackgroundService
    {
        private readonly ILogger<EmailSenderBackgroundWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IBackgroundQueue<EmailDto> _queue;

        public EmailSenderBackgroundWorker(ILogger<EmailSenderBackgroundWorker> logger, IServiceScopeFactory scopeFactory, IBackgroundQueue<EmailDto> queue)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{Type} is now running in the background.", nameof(EmailSenderBackgroundWorker));

            await BackgroundProcessing(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogCritical(
                "The {Type} is stopping due to a host shutdown, queued items might not be processed anymore.",
                nameof(EmailSenderBackgroundWorker)
            );

            return base.StopAsync(cancellationToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                EmailDto? emailDto = null;

                try
                {
                    await Task.Delay(500, stoppingToken);

                    emailDto = _queue.Dequeue();

                    if (emailDto is null) continue;

                    _logger.LogInformation("Email found! Sending...");

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetService<IEmailService>();

                        if (service != null) service.SendOrQueue(emailDto, true);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("An error occurred when adding a page visit. Exception: {@Exception}", ex);

                    if (emailDto is not null) _queue.Enqueue(emailDto);
                }
            }
        }
    }
}
