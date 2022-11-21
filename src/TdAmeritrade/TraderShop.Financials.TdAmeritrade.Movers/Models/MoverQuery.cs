namespace TraderShop.Financials.TdAmeritrade.Movers.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MoverQuery
    {
        /// <summary>
        /// <para>
        /// The Index symbol to get movers from.
        /// Default is <b>Nasdaq Composite</b>.
        /// Currently only supports the following index symbols :
        /// </para>
        /// <list type="bullet">
        /// <item><description>$DJI</description></item>
        /// <item><description>$COMPX</description></item>
        /// <item><description>$SPX.X</description></item>
        /// </list>
        /// </summary>
        public string IndexSymbol { get; set; } = "$DJI";
        /// <summary>
        /// To return movers with the specified directions of up or down.
        /// Default is <b>up</b>
        /// </summary>
        public Direction Direction { get; set; } = Direction.up;

        /// <summary>
        /// To return movers with the specified change types of percent or value.
        /// Default is <b>percent</b>
        /// </summary>
        public Change Change { get; set; } = Change.percent;
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// 
        /// </summary>
        up,
        /// <summary>
        /// 
        /// </summary>
        down
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Change
    {
        /// <summary>
        /// 
        /// </summary>
        value,
        /// <summary>
        /// 
        /// </summary>
        percent
    }
}
