using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public interface IUserInfoStore
{
    Task<UserInfo?> GetOrNullAsync(string? key = null);

    Task SetAsync(UserInfo userInfo, string? key = null);
}
