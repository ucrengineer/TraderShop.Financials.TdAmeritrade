using TraderShop.Financials.TdAmeritrade.Instruments.Models;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models
{
    public class Order
    {
        public string Session { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string OrderType { get; set; } = string.Empty;
        public CancelTime CancelTime { get; set; } = new CancelTime();
        public string ComplexOrderStrategyType { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public double FilledQuantity { get; set; }
        public double RemainingQuantity { get; set; }
        public string RequestedDestination { get; set; } = string.Empty;
        public string DestinationLinkName { get; set; } = string.Empty;
        public string ReleaseTime { get; set; } = string.Empty;
        public double StopPrice { get; set; }
        public string StopPriceLinkBasis { get; set; } = string.Empty;
        public string StopPriceLinkType { get; set; } = string.Empty;
        public double StopPriceOffset { get; set; }
        public string StopType { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string PriceLinkBasis { get; set; } = string.Empty;
        public string PriceLinkType { get; set; } = string.Empty;
        public string TaxLotMethod { get; set; } = string.Empty;
        public OrderLeg[] OrderLegCollection { get; set; } = new OrderLeg[0];
        public double ActivationPrice { get; set; }
        public string SpecialInstruction { get; set; } = string.Empty;
        public string OrderStrategyType { get; set; } = string.Empty;
        public double OrderId { get; set; }
        public bool Cancelable { get; set; }
        public bool Editable { get; set; }
        public string Status { get; set; } = string.Empty;
        public string EnteredTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public double AccountId { get; set; }
        public OrderActivity[] OrderActivityCollection { get; set; } = new OrderActivity[0];
        public Order[] ReplacingOrderCollection { get; set; } = new Order[0];
        public Order[] ChildOrderStrategies { get; set; } = new Order[0];
        public string StatusDescription { get; set; } = string.Empty;
    }

    public class OrderRoot
    {
        public Order Order { get; set; } = new Order();
    }

    public class CancelTime
    {
        public DateTime Date { get; set; }
        public bool ShortFormat { get; set; }
    }

    public class OrderLeg
    {
        public string OrderLegType { get; set; } = string.Empty;
        public double LegId { get; set; }
        public Instrument Instrument { get; set; } = new Instrument();
        public string Instruction { get; set; } = string.Empty;
        public string PositionEffect { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string QuantityType { get; set; } = string.Empty;
    }

    public class OrderInstrment : Instrument
    {
        public string MaturityDate { get; set; } = string.Empty;
        public double VariableRate { get; set; }
        public double Factor { get; set; }
        public string Type { get; set; } = string.Empty;
        public string PutCall { get; set; } = string.Empty;
        public string UnderlyingSymbol { get; set; } = string.Empty;
        public double OptionMultiplier { get; set; }
        public OptionDeliverables[] OptionDeliverables { get; set; } = new OptionDeliverables[0];
    }

    public class OptionDeliverables
    {
        public string Symbol { get; set; } = string.Empty;
        public double DeliverableUnits { get; set; }
        public string CurrencyType { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;
    }
    public class OrderActivity
    {
        public string ActivityType { get; set; } = string.Empty;
        public string ExecutionType { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public double OrderRemainingQuantity { get; set; }
        public ExecutionLeg[] ExecutionLegs { get; set; } = new ExecutionLeg[0];


    }
    public class ExecutionLeg
    {
        public double LegId { get; set; }
        public double Quantity { get; set; }
        public double MisMarkedQuantity { get; set; }
        public double Price { get; set; }
        public string Time { get; set; } = string.Empty;
    }
}
