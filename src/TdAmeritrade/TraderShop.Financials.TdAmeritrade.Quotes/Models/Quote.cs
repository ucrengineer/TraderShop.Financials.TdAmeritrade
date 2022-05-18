using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class Quote : Instrument
    {
        public string ExchangeName { get; set; } = string.Empty;
        public string SecurityStatus { get; set; } = string.Empty;
    }
}
