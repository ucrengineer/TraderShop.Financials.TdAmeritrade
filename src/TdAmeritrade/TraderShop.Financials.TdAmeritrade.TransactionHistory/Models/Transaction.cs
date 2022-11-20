using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ClearingReferenceNumber { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SubAccount { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SettlementDate { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double Sma { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RequirementReallocationAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double DayTradeBuyingPowerEffect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double NetAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransactionDate { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransactionSubType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool CashBalanceEffectFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AchStatus { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double AccruedInterest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Fees? Fees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TransactionItem? TransactionItem { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Fees
    {
        /// <summary>
        /// 
        /// </summary>
        public double RFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AdditionalFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double CDSCFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RegFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OtherCharges { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Commission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OptRegFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double SecFee { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransactionItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double AccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ParentOrderKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ParentChildIndicator { get; set; } = string.Empty;
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
        public TransactionInstrument? Instrument { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransactionInstrument : Instrument
    {
        /// <summary>
        /// 
        /// </summary>
        public string UnderlyingSymbol { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime OptionExpirationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OptionStrikePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PutCall { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime BondMaturityDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BondInterestRate { get; set; }
    }
}
