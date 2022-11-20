namespace TraderShop.Financials.TdAmeritrade.PriceHistory.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Candle
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Volume { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PriceHistoryRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public Candle[] Candles { get; set; } = new Candle[0];

        /// <summary>
        /// 
        /// </summary>
        public bool Empty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Symbmol { get; set; } = string.Empty;

    }
}
