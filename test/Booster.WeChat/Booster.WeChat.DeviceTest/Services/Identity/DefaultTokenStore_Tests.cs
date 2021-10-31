using Booster.WeChat.Models.Identity;
using Booster.WeChat.Services.Identity;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Maui.Essentials;

namespace Booster.WeChat.DeviceTest.Services.Identity
{
    public class DefaultTokenStore_Tests
    {
        [Fact]
        public async Task Should_Get_Null_Default()
        {
            SecureStorage.RemoveAll();

            var _tokenStore = new DefaultTokenStore();
            var token = await _tokenStore.GetOrNullAsync();

            token.ShouldBeNull();
        }

        [Fact]
        public async Task Null_Token_Should_Throw()
        {
            var _tokenStore = new DefaultTokenStore();
            Token token = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => _tokenStore.SetAsync(token));
        }

        [Fact]
        public async Task Should_Set_And_Get_Token()
        {
            var _tokenStore = new DefaultTokenStore();
            var token = new Token()
            {
                AccessToken = "ACCESS TOKEN",
                ExpiresIn = 7200,
                RefreshToken = "REFRESH TOKEN",
                OpenId = "OPEN ID",
                Scope = "SCOPE",
                IssuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            await _tokenStore.SetAsync(token);

            var result = await _tokenStore.GetOrNullAsync();
            result.ShouldBeEquivalentTo(token);
        }
    }
}
