using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.Services
{
    public interface ITdAmeritradeClientService
    {
        Task<PostAccessTokenResponse> GetAccessToken();
    }
}
