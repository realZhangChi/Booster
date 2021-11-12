using System;
using System.Threading.Tasks;

using Booster.WeChat.Services.Identity;
using Booster.WeChat.Test.Mock;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

using Shouldly;

using Xunit;

namespace Booster.WeChat.DeviceTest.Services.Identity
{
    public class DefaultAuthorizationService_Tests
    {
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
            var handler = new MockPlatformAuthorizer();
            var userInfoStore = new MockUserInfoStore();
            var tokenStore = new MockTokenStore();
            var weChatHttpClient = MockWeChatHttpClient.SuccessInstance;
            var service = new DefaultAuthorizationService(handler, tokenStore, userInfoStore, weChatHttpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(nullAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(whiteSpaceAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, nullAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, whiteSpaceAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, appSecret, nullCode));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AuthorizeCallbackAsync(appId, appSecret, whiteSpaceCode));
            
            // clean
            SecureStorage.RemoveAll();
        }

        [Fact]
        public async Task Callback_Should_Set_and_Get_Token_and_UserInfo()
        {
            var appId = "AppId";
            var appSecret = "AppSecret";
            var code = "Code";
            var handler = new MockPlatformAuthorizer();
            var userInfoStore = new MockUserInfoStore();
            var tokenStore = new MockTokenStore();
            var weChatHttpClient = MockWeChatHttpClient.SuccessInstance;
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

            // clean
            SecureStorage.RemoveAll();
        }

        [Fact]
        public async Task Authorization_Success_Should_Get_Message()
        {
            var appId = "AppId";
            var appSecret = "AppSecret";
            var code = "Code";
            var handler = new MockPlatformAuthorizer();
            var userInfoStore = new MockUserInfoStore();
            var tokenStore = new MockTokenStore();
            var weChatHttpClient = MockWeChatHttpClient.SuccessInstance;
            var service = new DefaultAuthorizationService(handler, tokenStore, userInfoStore, weChatHttpClient);
            AuthorizationMessageArgs message = null;
            MessagingCenter.Subscribe<IAuthorizationService, AuthorizationMessageArgs>(
                this,
                AuthorizationMessages.Success,
                (_, args) => message = args);

            await service.AuthorizeCallbackAsync(appId, appSecret, code);

            message.ShouldBe(AuthorizationMessageArgs.SuccessInstance());
            
            // clean
            MessagingCenter.Unsubscribe<IAuthorizationService, AuthorizationMessageArgs>(this, AuthorizationMessages.Success);
            SecureStorage.RemoveAll();
        }

        [Fact]
        public async Task Authorization_Fail_Should_Get_Message()
        {
            var appId = "AppId";
            var appSecret = "AppSecret";
            var code = "Code";
            var handler = new MockPlatformAuthorizer();
            var userInfoStore = new MockUserInfoStore();
            var tokenStore = new MockTokenStore();
            var weChatHttpClient = MockWeChatHttpClient.FailInstance;
            var service = new DefaultAuthorizationService(handler, tokenStore, userInfoStore, weChatHttpClient);
            AuthorizationMessageArgs message = null;
            MessagingCenter.Subscribe<IAuthorizationService, AuthorizationMessageArgs>(
                this,
                AuthorizationMessages.Failed,
                (_, args) => message = args);

            await service.AuthorizeCallbackAsync(appId, appSecret, code);

            message.IsSuccess.ShouldBeFalse();
            
            // clean
            MessagingCenter.Unsubscribe<IAuthorizationService, AuthorizationMessageArgs>(this, AuthorizationMessages.Failed);
            SecureStorage.RemoveAll();
        }
    }
}
