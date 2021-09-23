using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public class NullTokenService : ITokenService
{
    public Task<Token?> GetTokenFromWeChatAsync(string code)
    {
        return Task.FromResult((Token?)null);
    }

    public Task<Token?> RefreshTokenAsync()
    {
        return Task.FromResult((Token?)null);
    }
}
