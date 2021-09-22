using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync();

    Task GetTokenAsync(string code);
}
