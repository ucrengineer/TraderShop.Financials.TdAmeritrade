namespace TraderShop.Financials.TdAmeritrade.Movers.Models
{
    public class Mover
    {
        public double Change { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public double Last { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public double TotalVolume { get; set; }
    }
}
