using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

internal class NullAuthorizationHandler : IAuthorizationHandler
{
    public Task<bool> AuthorizeAsync()
    {
        return Task.FromResult(false);
    }
}
