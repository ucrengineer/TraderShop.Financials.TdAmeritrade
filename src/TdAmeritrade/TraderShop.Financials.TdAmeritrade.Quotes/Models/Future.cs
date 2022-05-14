namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class Future : Quote
    {
        public string AskId { get; set; } = string.Empty;
        public string BidId { get; set; } = string.Empty;
        public double BidPriceInDouble { get; set; }
        public double AskPriceInDouble { get; set; }
        public double LastPriceInDouble { get; set; }
        public double HighPriceInDouble { get; set; }
        public double LowPriceInDouble { get; set; }
        public double ChangeInDouble { get; set; }
        public string FutureActiveSymbol { get; set; } = string.Empty;
        public double FutureMultiplier { get; set; }
        public string FuturePriceFormat { get; set; } = string.Empty;
        public double FutureSettlementPrice { get; set; }
        public string LastId { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public double OpenPriceInDouble { get; set; }
        public double Tick { get; set; }
        public double TickAmount { get; set; }
        public double Mark { get; set; }
        public DateTime FutureExpirationDate { get; set; }
        public bool FutureIsActive { get; set; }
        public bool FutureIsTradable { get; set; }
        public double FuturePercentageChange { get; set; }
        public string FutureTradingHours { get; set; } = string.Empty;
        public double OpenInterest { get; set; }
    }
}
