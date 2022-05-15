namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class Option : Quote
    {
        public double BidPrice { get; set; }
        public double BidSize { get; set; }
        public double AskPrice { get; set; }
        public double AskSize { get; set; }
        public double LastPrice { get; set; }
        public double LastSize { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
        public double NetChange { get; set; }
        public double TotalVolume { get; set; }
        public long QuoteTimeInLong { get; set; }
        public long TradeTimeInLong { get; set; }
        public double Mark { get; set; }
        public double Volatility { get; set; }
        public string ContractType { get; set; } = string.Empty;
        public string Deliverables { get; set; } = string.Empty;
        public double Delta { get; set; }
        public double Gamma { get; set; }
        public double MoneyIntrinsicValue { get; set; }
        public double Multiplier { get; set; }
        public double OpenInterest { get; set; }
        public double Rho { get; set; }
        public string SettlementType { get; set; } = string.Empty;
        public double StrikePrice { get; set; }
        public double TheoreticalOptionValue { get; set; }
        public double Theta { get; set; }
        public double TimeValue { get; set; }
        public string Underlying { get; set; } = string.Empty;
        public double UnderlyingPrice { get; set; }
        public string UvExpirationType { get; set; } = string.Empty;
        public double Vega { get; set; }

    }
}
