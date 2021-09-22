using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public class Token
{
    public string AccessToken { get; set; }

    public int ExpiresIn { get; set; }

    public string RefreshToken { get; set; }

    public string OpenId { get; set; }

    public string Scope { get; set; }

    public string UnionId { get; set; }
}
