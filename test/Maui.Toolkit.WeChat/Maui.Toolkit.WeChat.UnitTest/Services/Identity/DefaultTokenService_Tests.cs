using Maui.Toolkit.WeChat.Services.Http;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Services.Identity
{
    public class DefaultTokenService_Tests
    {
        [Fact]
        public async Task GetTokenFromWeChat_Should_Not_Be_Null()
        {
            var tokenService = new DefaultTokenService(new MockWeChatHttpClient());
            var appId = "AppId";
            var appSercret = "AppSecret";
            var code = "Code";

            var token = await tokenService.GetTokenFromWeChatAsync(appId, appSercret, code);

            token.ShouldNotBeNull();
        }

        [Fact]
        public async Task RefreshToken_Should_Not_Be_Null()
        {
            var tokenService = new DefaultTokenService(new MockWeChatHttpClient());
            var appId = "AppId";
            var refreshToken = "RefreshToken";

            var token = await tokenService.RefreshTokenAsync(appId, refreshToken);

            token.ShouldNotBeNull();
        }

        public async Task Token_IssueAt_Should_Correct()
        {
            var tokenService = new DefaultTokenService(new MockWeChatHttpClient());
            var appId = "AppId";
            var appSercret = "AppSecret";
            var code = "Code";
            var refreshToken = "RefreshToken";
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var token = await tokenService.GetTokenFromWeChatAsync(appId, appSercret, code);
            var newToken = await tokenService.RefreshTokenAsync(appId, refreshToken);

            token!.IssuedAt.ShouldBeGreaterThan(now);
            token!.IssuedAt.ShouldBeLessThan(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            newToken!.IssuedAt.ShouldBeGreaterThan(now);
            newToken!.IssuedAt.ShouldBeLessThan(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }


        [Fact]
        public async Task GetTokenFromWeChat_Should_Throw_If_Argument_Is_Null()
        {
            var tokenService = new DefaultTokenService(new MockWeChatHttpClient());
            var appId = "AppId";
            var nullAppId = (string)null!;
            var whiteSpaceAppId = " ";
            var appSecret = "AppSecret";
            var nullAppSecret = (string)null!;
            var whiteSpaceAppSecret = " ";
            var code = "Code";
            var nullCode = (string)null!;
            var whiteSpaceCode = " ";

            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.GetTokenFromWeChatAsync(nullAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.GetTokenFromWeChatAsync(whiteSpaceAppId, appSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.GetTokenFromWeChatAsync(appId, nullAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.GetTokenFromWeChatAsync(appId, whiteSpaceAppSecret, code));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.GetTokenFromWeChatAsync(appId, appSecret, nullCode));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.GetTokenFromWeChatAsync(appId, nullAppSecret, whiteSpaceCode));
        }

        [Fact]
        public async Task RefreshToken_Should_Throw_If_Argument_Is_Null()
        {
            var tokenService = new DefaultTokenService(new MockWeChatHttpClient());
            var appId = "AppId";
            var nullAppId = (string)null!;
            var whiteSpaceAppId = " ";
            var refreshToken = "RefreshToken";
            var nullRefreshToken = (string)null!;
            var whiteSpaceRefreshToken = " ";

            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.RefreshTokenAsync(nullAppId, refreshToken));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.RefreshTokenAsync(whiteSpaceAppId, refreshToken));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.RefreshTokenAsync(appId, nullRefreshToken));
            await Assert.ThrowsAsync<ArgumentNullException>(() => tokenService.RefreshTokenAsync(appId, whiteSpaceRefreshToken));
        }
    }
}
