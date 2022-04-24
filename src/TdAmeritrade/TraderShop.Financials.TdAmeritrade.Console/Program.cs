// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Symbols.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Symbols.Services;

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
                services.AddTdAmeritradeSymbolProvider();

            })
            .UseEnvironment("development")
            .RunConsoleAsync();
    }

    internal sealed class ConsoleHostService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ITdAmeritradeAuthService _tdClient;
        private readonly ITdAmeritradeSymbolProvider _tdSymbolProvider;
        private readonly IOptionsMonitor<TdAmeritradeOptions> _tdOptions;


        public ConsoleHostService(
            ILogger<ConsoleHostService> logger,
            IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions,
            IHostApplicationLifetime appLifetime,
            ITdAmeritradeSymbolProvider tdClient,
            ITdAmeritradeAuthService TdAmeritradeAuthService)
        {
            _logger = logger;
            _tdOptions = tdAmeritradeOptions;
            _applicationLifetime = appLifetime;
            _tdClient = TdAmeritradeAuthService;
            _tdSymbolProvider = tdClient;
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
                        _logger.LogInformation($"{_tdOptions.CurrentValue.access_token}");

                        _logger.LogInformation($"{_tdOptions.CurrentValue.access_token}");

                        var instruments = await _tdSymbolProvider.GetInstruments();

                        _logger.LogInformation($"{instruments.Count}");

                        var futures = await _tdSymbolProvider.GetAllFuturesInstruments();

                        _logger.LogInformation($"{futures.Count}");

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
