namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Models
{
    public class Candle
    {
        public decimal Close { get; set; }

        public long DateTime { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Open { get; set; }

        public long Volume { get; set; }
    }

    public class PriceHistoryRoot
    {
        public Candle[] Candles { get; set; } = new Candle[0];

        public bool Empty { get; set; }

        public string Symbmol { get; set; } = string.Empty;

    }
}
