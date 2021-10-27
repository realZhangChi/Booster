using Maui.Toolkit.WeChat.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Services.Http
{
    public class DefaultWeChatHttpClient_Tests
    {
        [Fact]
        public async Task GetToken_Should_Throw_If_errcode_Not_Zero()
        {
            var httpClient = MockHttpClient.InstanceWithFailureResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var appId = "AppId";
            var appSecret = "AppSecret";
            var code = "Code";

            await Assert.ThrowsAsync<HttpRequestException>(() => weChatClient.GetTokenAsync(appId, appSecret, code));
        }

        [Fact]
        public async Task GetToken_Should_Throw_If_Argument_Is_Null()
        {
            var httpClient = MockHttpClient.InstanceWithSuccessResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var appId = "AppId";
            var nullAppId = (string)null!;
            var whiteSpaceAppId = " ";
            var appSecret = "AppSecret";
            var nullAppSecret = (string)null!;
            var whiteSpaceAppSecret = " ";
            var code = "Code";
            var nullCode = (string)null!;
            var whiteSpaceCode = " ";

            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetTokenAsync(nullAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetTokenAsync(whiteSpaceAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetTokenAsync(appId, nullAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetTokenAsync(appId, whiteSpaceAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetTokenAsync(appId, appSecret, nullCode));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetTokenAsync(appId, nullAppSecret, whiteSpaceCode));
        }

        [Fact]
        public async Task GetToken_Should_Success()
        {
            var httpClient = MockHttpClient.InstanceWithSuccessResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var appId = "AppId";
            var appSecret = "AppSecret";
            var code = "Code";

            var token = await weChatClient.GetTokenAsync(appId, appSecret, code);

            token.ShouldBeEquivalentTo(MockHttpClient.Token);
        }

        [Fact]
        public async Task GetUserInfo_Should_Throw_If_errcode_Not_Zero()
        {
            var httpClient = MockHttpClient.InstanceWithFailureResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var accessToken = "AccessToken";
            var openId = "OpenId";

            await Assert.ThrowsAsync<HttpRequestException>(() => weChatClient.GetUserInfoAsync(accessToken, openId));
        }

        [Fact]
        public async Task GetUserInfo_Should_Throw_If_Argument_Is_Null()
        {
            var httpClient = MockHttpClient.InstanceWithSuccessResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var accessToken = "AccessToken";
            var nullaccessToken = (string)null!;
            var whiteSpaceaccessToken = " ";
            var openId = "OpenId";
            var nullOpenId = (string)null!;
            var whiteSpaceOpenId = " ";

            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetUserInfoAsync(nullaccessToken, openId));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetUserInfoAsync(whiteSpaceaccessToken, openId));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetUserInfoAsync(accessToken, nullOpenId));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.GetUserInfoAsync(accessToken, whiteSpaceOpenId));
        }

        [Fact]
        public async Task GetUserInfo_Should_Success()
        {
            var httpClient = MockHttpClient.InstanceWithSuccessResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var accessToken = "AccessToken";
            var openId = "OpenId";

            var userInfo = await weChatClient.GetUserInfoAsync(accessToken, openId);

            userInfo.ShouldBeEquivalentTo(MockHttpClient.UserInfo);
        }

        [Fact]
        public async Task RefreshToken_Should_Throw_If_errcode_Not_Zero()
        {
            var httpClient = MockHttpClient.InstanceWithFailureResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var appId = "AppId";
            var refreshToken = "RefreshToken";

            await Assert.ThrowsAsync<HttpRequestException>(() => weChatClient.RefreshTokenAsync(appId, refreshToken));
        }

        [Fact]
        public async Task RefreshToken_Should_Throw_If_Argument_Is_Null()
        {
            var httpClient = MockHttpClient.InstanceWithSuccessResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var appId = "AppId";
            var nullAppId = (string)null!;
            var whiteSpaceAppId = " ";
            var refreshToken = "RefreshToken";
            var nullRefreshToken = (string)null!;
            var whiteSpaceRefreshToken = " ";

            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.RefreshTokenAsync(nullAppId, refreshToken));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.RefreshTokenAsync(whiteSpaceAppId, refreshToken));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.RefreshTokenAsync(appId, nullRefreshToken));
            await Assert.ThrowsAsync<ArgumentNullException>(() => weChatClient.RefreshTokenAsync(appId, whiteSpaceRefreshToken));
        }

        [Fact]
        public async Task RefreshToken_Should_Success()
        {
            var httpClient = MockHttpClient.InstanceWithSuccessResponse;
            var weChatClient = new DefaultWeChatHttpClient(httpClient);
            var appId = "AppId";
            var refreshToken = "RefreshToken";

            var token = await weChatClient.RefreshTokenAsync(appId, refreshToken);

            token.ShouldBeEquivalentTo(MockHttpClient.Token);
        }
    }
}
