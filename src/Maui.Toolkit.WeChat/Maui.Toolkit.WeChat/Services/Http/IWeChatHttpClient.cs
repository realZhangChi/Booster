using Maui.Toolkit.WeChat.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Http;

public interface IWeChatHttpClient
{
    Task<Token?> GetTokenAsync(string code);

    Task<Token?> RefreshTokenAsync(string refreshToken);

    Task<UserInfo?> GetUserInfoAsync(Token token);
}
