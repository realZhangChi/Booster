using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Services.Identity;

public class NullAuthorizationService : IAuthorizationService
{
    public Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(false);
    }

    public Task AuthorizedAsync(string code)
    {
        return Task.CompletedTask;
    }
}
