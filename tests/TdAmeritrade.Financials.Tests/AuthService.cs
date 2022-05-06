using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using Xunit;

namespace TdAmeritrade.Financials.Tests
{
    public class AuthService
    {
        private readonly ITdAmeritradeAuthService _authService;
        private readonly IMemoryCache _cache;

        public AuthService()
        {
            _authService = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeAuthService>();
            _cache = TestHelper.GetServiceProvider().GetRequiredService<IMemoryCache>();

        }

        [Fact]
        public async Task Returns_Bearer_Token_Successfully()
        {
            var token = await _authService.GetBearerToken();

            Assert.NotNull(token);

        }
    }
}
