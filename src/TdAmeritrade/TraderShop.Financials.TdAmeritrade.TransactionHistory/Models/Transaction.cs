using TraderShop.Financials.TdAmeritrade.Instruments.Models;

namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Models
{
    public class Transaction
    {
        public string Type { get; set; } = string.Empty;
        public string ClearingReferenceNumber { get; set; } = string.Empty;
        public string SubAccount { get; set; } = string.Empty;
        public string SettlementDate { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public double Sma { get; set; }
        public double RequirementReallocationAmount { get; set; }

        public double DayTradeBuyingPowerEffect { get; set; }

        public double NetAmount { get; set; }
        public string TransactionDate { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string TransactionSubType { get; set; } = string.Empty;
        public double TransactionId { get; set; }

        public bool CashBalanceEffectFlag { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AchStatus { get; set; } = string.Empty;
        public double AccruedInterest { get; set; }

        public Fees? Fees { get; set; }

        public TransactionItem? TransactionItem { get; set; }
    }

    public class Fees
    {
        public double RFee { get; set; }
        public double AdditionalFee { get; set; }
        public double CDSCFee { get; set; }
        public double RegFee { get; set; }
        public double OtherCharges { get; set; }
        public double Commission { get; set; }
        public double OptRegFee { get; set; }
        public double SecFee { get; set; }
    }

    public class TransactionItem
    {
        public double AccountId { get; set; }

        public double Account { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public double ParentOrderKey { get; set; }
        public string ParentChildIndicator { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public string PositionEffect { get; set; } = string.Empty;

        public TransactionInstrument? Instrument { get; set; }
    }

    public class TransactionInstrument : Instrument
    {
        public string UnderlyingSymbol { get; set; } = string.Empty;
        public DateTime OptionExpirationDate { get; set; }
        public double OptionStrikePrice { get; set; }
        public string PutCall { get; set; } = string.Empty;

        public DateTime BondMaturityDate { get; set; }
        public double BondInterestRate { get; set; }
    }
}
