using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public interface IAuthorizationHandler
{
    Task<bool> AuthorizeAsync();
}
