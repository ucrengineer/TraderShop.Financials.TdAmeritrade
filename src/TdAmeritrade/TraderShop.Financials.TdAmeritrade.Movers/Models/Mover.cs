namespace TraderShop.Financials.TdAmeritrade.Movers.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Mover
    {
        /// <summary>
        /// 
        /// </summary>
        public double Change { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Direction { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double Last { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double TotalVolume { get; set; }
    }
}
