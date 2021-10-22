using Maui.Toolkit.WeChat.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Http
{
    internal class MockWeChatHttpClient : IWeChatHttpClient
    {
        public Task<Token?> GetTokenAsync(string appId, string appSecret, string code)
        {
            return Task.FromResult<Token?>(new Token());
        }

        public Task<UserInfo?> GetUserInfoAsync(string accessToken, string openId)
        {
            return Task.FromResult<UserInfo?>(new UserInfo());
        }

        public Task<Token?> RefreshTokenAsync(string appId, string refreshToken)
        {
            return Task.FromResult<Token?>(new Token());
        }
    }
}
