
namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models
{
    /// <summary>
    /// Tdameritrade order model
    /// </summary>
    public class Order
    {
        /// <summary>
        /// <para>
        ///     "session": "'NORMAL' or 'AM' or 'PM' or 'SEAMLESS'",
        /// </para>
        /// </summary>
        public string Session { get; set; } = string.Empty;
        /// <summary>
        /// <para>
        ///     "duration": "'DAY' or 'GOOD_TILL_CANCEL' or 'FILL_OR_KILL'",
        /// </para>
        /// </summary>
        public string Duration { get; set; } = string.Empty;
        /// <summary>
        /// <para>
        ///     "orderType": "'MARKET' or 'LIMIT' or 'STOP' or 'STOP_LIMIT' or 'TRAILING_STOP' or 'MARKET_ON_CLOSE' or 'EXERCISE' or 'TRAILING_STOP_LIMIT' or 'NET_DEBIT' or 'NET_CREDIT' or 'NET_ZERO'",
        /// </para>
        /// </summary>
        public string OrderType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public CancelTime CancelTime { get; set; } = new CancelTime();
        /// <summary>
        /// <para>
        ///     "complexOrderStrategyType": "'NONE' or 'COVERED' or 'VERTICAL' or 'BACK_RATIO' or 'CALENDAR' or 'DIAGONAL' or 'STRADDLE' or 'STRANGLE' or 'COLLAR_SYNTHETIC' or 'BUTTERFLY' or 'CONDOR' or 'IRON_CONDOR' or 'VERTICAL_ROLL' or 'COLLAR_WITH_STOCK' or 'DOUBLE_DIAGONAL' or 'UNBALANCED_BUTTERFLY' or 'UNBALANCED_CONDOR' or 'UNBALANCED_IRON_CONDOR' or 'UNBALANCED_VERTICAL_ROLL' or 'CUSTOM'",
        /// </para>
        /// </summary>
        public string ComplexOrderStrategyType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double FilledQuantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double RemainingQuantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string RequestedDestination { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string DestinationLinkName { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string ReleaseTime { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double StopPrice { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string StopPriceLinkBasis { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string StopPriceLinkType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double StopPriceOffset { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string StopType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string Price { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string PriceLinkBasis { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string PriceLinkType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string TaxLotMethod { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public OrderLeg[] OrderLegCollection { get; set; } = new OrderLeg[0];
        /// <summary>
        ///
        /// </summary>
        public double ActivationPrice { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string SpecialInstruction { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string OrderStrategyType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double OrderId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool Cancelable { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool Editable { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string EnteredTime { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string CloseTime { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string Tag { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double AccountId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public OrderActivity[] OrderActivityCollection { get; set; } = new OrderActivity[0];
        /// <summary>
        ///
        /// </summary>
        public Order[] ReplacingOrderCollection { get; set; } = new Order[0];
        /// <summary>
        ///
        /// </summary>
        public Order[] ChildOrderStrategies { get; set; } = new Order[0];
        /// <summary>
        ///
        /// </summary>
        public string StatusDescription { get; set; } = string.Empty;
    }

    /// <summary>
    ///
    /// </summary>
    public class OrderRoot
    {
        /// <summary>
        ///
        /// </summary>
        public Order Order { get; set; } = new Order();
    }

    /// <summary>
    ///
    /// </summary>
    public class CancelTime
    {
        /// <summary>
        ///
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool ShortFormat { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class OrderLeg
    {
        /// <summary>
        ///
        /// </summary>
        public string OrderLegType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double LegId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Instrument Instrument { get; set; } = new Instrument();
        /// <summary>
        ///
        /// </summary>
        public string Instruction { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string PositionEffect { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string QuantityType { get; set; } = string.Empty;
    }

    /// <summary>
    ///
    /// </summary>
    public class OrderInstrment : Instrument
    {
        /// <summary>
        ///
        /// </summary>
        public string MaturityDate { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double VariableRate { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double Factor { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string PutCall { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string UnderlyingSymbol { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double OptionMultiplier { get; set; }
        /// <summary>
        ///
        /// </summary>
        public OptionDeliverables[] OptionDeliverables { get; set; } = new OptionDeliverables[0];
    }

    /// <summary>
    ///
    /// </summary>
    public class OptionDeliverables
    {
        /// <summary>
        ///
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double DeliverableUnits { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string CurrencyType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string AssetType { get; set; } = string.Empty;
    }
    /// <summary>
    ///
    /// </summary>
    public class OrderActivity
    {
        /// <summary>
        ///
        /// </summary>
        public string ActivityType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string ExecutionType { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double OrderRemainingQuantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public ExecutionLeg[] ExecutionLegs { get; set; } = new ExecutionLeg[0];


    }
    /// <summary>
    ///
    /// </summary>
    public class ExecutionLeg
    {
        /// <summary>
        ///
        /// </summary>
        public double LegId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double MisMarkedQuantity { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Time { get; set; } = string.Empty;
    }
}
