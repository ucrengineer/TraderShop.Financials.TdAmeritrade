namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Future : Quote
    {
        /// <summary>
        /// 
        /// </summary>
        public string AskId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string BidId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double BidPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AskPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LastPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HighPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LowPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ChangeInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FutureActiveSymbol { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double FutureMultiplier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FuturePriceFormat { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double FutureSettlementPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Product { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double OpenPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Tick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TickAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FutureExpirationDate { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public bool FutureIsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FutureIsTradable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double FuturePercentageChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FutureTradingHours { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double OpenInterest { get; set; }
    }
}
