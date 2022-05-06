using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using Xunit;
using Xunit.Abstractions;

namespace TdAmeritrade.Financials.Tests
{
    public class AuthService
    {
        private readonly ITdAmeritradeAuthService _authService;

        private readonly ITestOutputHelper _output;

        public AuthService(ITestOutputHelper output)
        {
            _authService = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeAuthService>();
            _output = output;
        }

        [Fact]
        public async Task Returns_Bearer_Token_Successfully()
        {
            var token = await _authService.GetBearerToken();

            Assert.NotNull(token);

            _output.WriteLine(token);
        }
    }
}
