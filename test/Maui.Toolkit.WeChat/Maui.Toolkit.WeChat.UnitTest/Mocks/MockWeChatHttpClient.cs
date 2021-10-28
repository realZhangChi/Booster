using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Mocks
{
    internal class MockWeChatHttpClient : IWeChatHttpClient
    {
        public Task<Token> GetTokenAsync(string appId, string appSecret, string code)
        {
            return Task.FromResult(MockHttpClient.Token);
        }

        public Task<UserInfo> GetUserInfoAsync(string accessToken, string openId)
        {
            return Task.FromResult(MockHttpClient.UserInfo);
        }

        public Task<Token> RefreshTokenAsync(string appId, string refreshToken)
        {
            return Task.FromResult(MockHttpClient.Token);
        }
    }
}
