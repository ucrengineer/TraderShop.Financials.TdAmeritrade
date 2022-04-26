using Microsoft.Extensions.Options;
using TraderShop.Finacials.TdAmeritrade.PriceHistory.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;

namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Services.Impl
{
    public class TdAmeritradePriceHistoryProvider : ITdAmeriradePriceHistoryProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;
        private TdAmeritradeOptions _tdAmeritradeOptions;
        public TdAmeritradePriceHistoryProvider(HttpClient httpClient, ITdAmeritradeAuthService tdAmeritradeAuthService, IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {
            _httpClient = httpClient;
            _authService = tdAmeritradeAuthService;
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
            tdAmeritradeOptions.OnChange(x => _tdAmeritradeOptions = x);
        }

        private bool PriceHistorySpecsValidator(PriceHistorySpecs specs)
        {
            return true;
        }
    }
}
