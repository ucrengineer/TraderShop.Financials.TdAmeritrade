namespace TraderShop.Financials.TdAmeritrade.MarketHours.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Hour
    {
        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Exchange { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public bool isOpen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MarketType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Product { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        //todo : update this model for a smoother transition
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, StartEndTimes[]>? SessionHours { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StartEndTimes
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime End { get; set; }
    }
}
