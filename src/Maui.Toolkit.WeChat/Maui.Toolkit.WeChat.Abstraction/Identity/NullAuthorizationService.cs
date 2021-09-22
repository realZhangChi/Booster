using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

internal class NullAuthorizationService : IAuthorizationService
{
    public Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(false);
    }

    public Task GetTokenAsync(string code)
    {
        return Task.CompletedTask;
    }
}
