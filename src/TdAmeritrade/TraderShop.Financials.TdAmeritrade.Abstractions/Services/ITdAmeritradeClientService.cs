namespace TraderShop.Financials.TdAmeritrade.Abstractions.Services
{
    public interface ITdAmeritradeClientService
    {
        Task<int> SetAccessToken();
    }
}
