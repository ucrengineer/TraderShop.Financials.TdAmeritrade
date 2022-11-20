namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Option : Quote
    {
        /// <summary>
        /// 
        /// </summary>
        public double BidPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BidSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AskPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AskSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LastPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LastSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OpenPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HighPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LowPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ClosePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double NetChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TotalVolume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long QuoteTimeInLong { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long TradeTimeInLong { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Volatility { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContractType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Deliverables { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double Delta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Gamma { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MoneyIntrinsicValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Multiplier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OpenInterest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Rho { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SettlementType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double StrikePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TheoreticalOptionValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Theta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TimeValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Underlying { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double UnderlyingPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UvExpirationType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double Vega { get; set; }

    }
}
