using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

internal class NullTokenService : ITokenService
{
    public Task<Token?> GetOrNullAsync()
    {
        return Task.FromResult((Token?)null);
    }

    public Task SetAsync(Token token)
    {
        return Task.CompletedTask;
    }
}
