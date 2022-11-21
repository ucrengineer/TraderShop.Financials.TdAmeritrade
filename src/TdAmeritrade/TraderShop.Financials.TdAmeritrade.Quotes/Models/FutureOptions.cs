namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FutureOptions : Quote
    {
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
        public double OpenPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Digits { get; set; }
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
        public string ContractType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double DeltaInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExerciseType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ExpirationType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double FutureExpirationDate { get; set; }
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
        public double GammaInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool InTheMoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MoneyIntrinsicValueInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MultiplierInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double NetChangeInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OpenInterest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RhoInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double StrikePriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ThetaInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TimeValueInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Underlying { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double VegaInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Volatility { get; set; }
    }
}
