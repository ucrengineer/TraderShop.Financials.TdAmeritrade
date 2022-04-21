// See https://aka.ms/new-console-template for more information

using TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<ConsoleHostService>();
                services.AddTdAmeritradeClient();
            })
            .RunConsoleAsync();

    }

    internal sealed class ConsoleHostService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public ConsoleHostService(
            ILogger<ConsoleHostService> logger,
            IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _applicationLifetime = appLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with argumetns : {string.Join(" ", Environment.GetCommandLineArgs())}");

            _applicationLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        _logger.LogInformation("Hello World!");

                        await Task.Delay(1000);

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled Exception!");
                    }
                    finally
                    {
                        _applicationLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }


}
