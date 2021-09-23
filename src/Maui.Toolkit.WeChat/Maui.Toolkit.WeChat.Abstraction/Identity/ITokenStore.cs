using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public interface ITokenStore
{
    Task<Token?> GetOrNullAsync(string? key = null);

    Task SetAsync(Token token, string? key = null);
}
