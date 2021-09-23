using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public interface ITokenService
{
    Task<Token?> GetTokenFromWeChatAsync(string code);

    Task<Token?> RefreshTokenAsync();
}
