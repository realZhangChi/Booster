using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Identity;

public class NullUserInfoService : IUserInfoService
{
    public Task<UserInfo?> GetUserInfoFromWeChatAsync(string? openId = null)
    {
        return Task.FromResult((UserInfo?)null);
    }
}
