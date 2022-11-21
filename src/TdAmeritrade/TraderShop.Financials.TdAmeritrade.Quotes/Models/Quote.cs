using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Quote : Instrument
    {
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SecurityStatus { get; set; } = string.Empty;
    }
}
