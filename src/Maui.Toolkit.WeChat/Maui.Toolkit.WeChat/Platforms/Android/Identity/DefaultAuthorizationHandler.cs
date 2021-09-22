﻿using Maui.Toolkit.WeChat.Identity;
using System.Threading.Tasks;
using Com.Tencent.MM.Opensdk.Modelmsg;
using Com.Tencent.MM.Opensdk.Openapi;

namespace Maui.Toolkit.WeChat.Platforms.Android.Identity;

internal class DefaultAuthorizationHandler : IAuthorizationHandler
{
    private readonly IWXAPI _wxApi;

    public DefaultAuthorizationHandler(IWXAPI wxApi)
    {
        _wxApi = wxApi;
    }

    public Task<bool> AuthorizeAsync()
    {
        var request = new SendAuth.Req()
        {
            Scope = "snsapi_userinfo",
            State = "wechat_sdk_demo_test"
        };
        var result = _wxApi.SendReq(request);

        return Task.FromResult(result);
    }
}
