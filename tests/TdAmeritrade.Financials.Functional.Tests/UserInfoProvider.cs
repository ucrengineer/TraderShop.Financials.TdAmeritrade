using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.UserInfo.Models;
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

            Assert.Contains(result!.Keys!, x => x.key.Any());

        }

        [Fact]
        public async Task Updates_Preferences_SuccessfullyAsync()
        {
            // arrange
            var updatedPreferences = new Preferences()
            {
                ExpressTrading = false,
                DirectOptionsRouting = false,
                DirectEquityRouting = false,
                DefaultEquityOrderLegInstruction = "BUY",
                DefaultEquityOrderType = "STOP",
                DefaultEquityOrderPriceLinkType = "NONE",
                DefaultEquityOrderDuration = "GOOD_TILL_CANCEL",
                DefaultEquityOrderMarketSession = "NORMAL",
                DefaultEquityQuantity = 0,
                MutualFundTaxLotMethod = "FIFO",
                EquityTaxLotMethod = "FIFO",
                OptionTaxLotMethod = "FIFO",
                DefaultAdvancedToolLaunch = "TA",
                AuthTokenTimeout = "FIFTY_FIVE_MINUTES"
            };

            // act
            var result = await _userInfoProvider.UpdatePreferences(_options.account_number, updatedPreferences);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public async Task Return_UserPrinciple_SuccessfullyAsync()
        {
            var result = await _userInfoProvider.GetUserPrincipals();

            Assert.NotNull(result);

            Assert.Equal(_options.account_number, result.PrimaryAccountId);
        }
    }
}
