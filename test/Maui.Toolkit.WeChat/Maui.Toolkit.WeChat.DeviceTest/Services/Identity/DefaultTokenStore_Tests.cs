using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Identity;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.DeviceTest.Services.Identity
{
    public class DefaultTokenStore_Tests
    {
        private readonly ITokenStore _tokenStore = new DefaultTokenStore();

        [Fact]
        public async Task Null_Token_Should_Throw()
        {
            Token token = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => _tokenStore.SetAsync(token));
        }

        [Fact]
        public async Task Should_Set_And_Get_Token()
        {
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

        [Fact]
        public async Task Should_Get_Null_Default()
        {
            var token = await _tokenStore.GetOrNullAsync();

            token.ShouldNotBeNull();
        }
    }
}
