namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class FutureOptions : Quote
    {
        public double BidPriceInDouble { get; set; }
        public double AskPriceInDouble { get; set; }
        public double LastPriceInDouble { get; set; }
        public double HighPriceInDouble { get; set; }
        public double LowPriceInDouble { get; set; }

        public double OpenPriceInDouble { get; set; }
        public double Digits { get; set; }
        public double Tick { get; set; }
        public double TickAmount { get; set; }
        public double Mark { get; set; }
        public string ContractType { get; set; } = string.Empty;
        public double DeltaInDouble { get; set; }
        public string ExerciseType { get; set; } = string.Empty;
        public string ExpirationType { get; set; } = string.Empty;
        public double FutureExpirationDate { get; set; }
        public bool FutureIsActive { get; set; }
        public bool FutureIsTradable { get; set; }
        public double FuturePercentageChange { get; set; }
        public string FutureTradingHours { get; set; } = string.Empty;
        public double GammaInDouble { get; set; }
        public bool InTheMoney { get; set; }
        public double MoneyIntrinsicValueInDouble { get; set; }
        public double MultiplierInDouble { get; set; }
        public double NetChangeInDouble { get; set; }
        public double OpenInterest { get; set; }
        public double RhoInDouble { get; set; }
        public double StrikePriceInDouble { get; set; }
        public double ThetaInDouble { get; set; }
        public double TimeValueInDouble { get; set; }
        public string Underlying { get; set; } = string.Empty;
        public double VegaInDouble { get; set; }
        public double Volatility { get; set; }
    }
}
