using Booster.WeChat.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booster.WeChat.Services.Identity
{
    public class DefaultAuthorizationService_Tests
    {
        [Fact]
        public async Task Authorize_Should_Success()
        {
            var handler = new MockAuthorizationHandler();
            var userInfoStore = new MockUserInfoStore();
            var tokenStore = new MockTokenStore();
            var weChatHttpClient = new MockWeChatHttpClient();
            var service = new DefaultAuthorizationService(handler, tokenStore, userInfoStore, weChatHttpClient);

            var result = await service.AuthorizeAsync();

            result.ShouldBeTrue();
        }

        [Fact]
        public async Task CallBack_Should_Throw_If_Argument_Is_Null()
        {
            var appId = "AppId";
            var nullAppId = (string)null!;
            var whiteSpaceAppId = " ";
            var appSecret = "AppSecret";
            var nullAppSecret = (string)null!;
            var whiteSpaceAppSecret = " ";
            var code = "Code";
            var nullCode = (string)null!;
            var whiteSpaceCode = " ";
            var handler = new MockAuthorizationHandler();
            var userInfoStore = new MockUserInfoStore();
            var tokenStore = new MockTokenStore();
            var weChatHttpClient = new MockWeChatHttpClient();
            var service = new DefaultAuthorizationService(handler, tokenStore, userInfoStore, weChatHttpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(nullAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(whiteSpaceAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, nullAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, whiteSpaceAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, appSecret, nullCode));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, appSecret, whiteSpaceCode));
        }

        [Fact]
        public async Task Callback_Should_Set_and_Get_Token_and_UserInfo()
        {
            var appId = "AppId";
            var appSecret = "AppSecret";
            var code = "Code";
            var handler = new MockAuthorizationHandler();
            var userInfoStore = new MockUserInfoStore();
            var tokenStore = new MockTokenStore();
            var weChatHttpClient = new MockWeChatHttpClient();
            var service = new DefaultAuthorizationService(handler, tokenStore, userInfoStore, weChatHttpClient);
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            await Task.Delay(1000);

            await service.AuthorizeCallbackAsync(appId, appSecret, code);
            var token = await tokenStore.GetOrNullAsync();
            var userInfo = await userInfoStore.GetOrNullAsync();
            
            await Task.Delay(1000);
            token.ShouldNotBeNull();
            token.IssuedAt.ShouldBeGreaterThan(now);
            token.IssuedAt.ShouldBeLessThan(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            userInfo.ShouldNotBeNull();
        }
    }
}
