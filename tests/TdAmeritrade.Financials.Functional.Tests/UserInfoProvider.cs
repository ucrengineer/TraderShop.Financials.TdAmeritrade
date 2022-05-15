using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.UserInfo.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class UserInfoProvider
    {
        private readonly ITdAmeritradeUserInfoProvider _userInfoProvider;
        private readonly TdAmeritradeOptions _options;

        public UserInfoProvider()
        {
            _userInfoProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeUserInfoProvider>();
            _options = TestHelper.GetServiceProvider().GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>().CurrentValue;

        }

        [Fact]
        public async Task Returns_Preferences_SuccessfullyAsync()
        {
            var result = await _userInfoProvider.GetPreferences(_options.account_number);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Returns_SubscriptionKeys_SuccessfullyAsync()
        {
            var result = await _userInfoProvider.GetStreamerSubscriptionKeys();

            Assert.NotNull(result);

            Assert.Contains(result.Keys, x => x.key.Any());

        }
    }
}
