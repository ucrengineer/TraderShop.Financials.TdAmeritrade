// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<ConsoleHostService>();
                services.AddTdAmeritradeClient();
                services.Configure<TdAmeritradeOptions>(
                    hostContext.Configuration.GetSection("TdAmeritradeOptions")
                        );
            })
            .RunConsoleAsync();

    }

    internal sealed class ConsoleHostService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ITdAmeritradeClientService _tdClient;
        private readonly IOptionsMonitor<TdAmeritradeOptions> _tdOptions;


        public ConsoleHostService(
            ILogger<ConsoleHostService> logger,
            IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions,
            IHostApplicationLifetime appLifetime,
            ITdAmeritradeClientService tdAmeritradeClientService)
        {
            _logger = logger;
            _tdOptions = tdAmeritradeOptions;
            _applicationLifetime = appLifetime;
            _tdClient = tdAmeritradeClientService;
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
                        var result = await _tdClient.GetAccessToken();
                        _logger.LogError($"{result.access_token}");
                        _logger.LogCritical($"{_tdOptions.CurrentValue.url}");

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
