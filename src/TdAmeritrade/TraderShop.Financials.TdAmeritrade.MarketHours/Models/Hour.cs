namespace TraderShop.Financials.TdAmeritrade.MarketHours.Models
{
    public class Hour
    {
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Exchange { get; set; } = string.Empty;

        public bool isOpen { get; set; }
        public string MarketType { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;

        //todo : update this model for a smoother transition
        public Dictionary<string, StartEndTimes[]>? SessionHours { get; set; }
    }

    public class StartEndTimes
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
