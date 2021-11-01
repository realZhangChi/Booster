using System;

using Android.Content;
using Android.OS;

using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Openapi;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;

namespace Booster.WeChat.Platforms.Android.WeChatApi;

public abstract class WeChatEntryActivity : MauiAppCompatActivity, IWXAPIEventHandler
{
    private readonly IWXAPI _wxApi;

    public WeChatEntryActivity()
    {
        _wxApi = MauiApplication.Current.Services.GetRequiredService<IWXAPI>();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);
        _wxApi.HandleIntent(intent, this);
    }

    public void OnReq(BaseReq? p0)
    {
        throw new NotImplementedException();
    }

    public async void OnResp(BaseResp? response)
    {
        if (response is null)
        {
            return;
        }

        if (response.Err_Code is BaseResp.IErrCode.ErrOk)
        {
            var handlerResolver = MauiApplication.Current.Services.GetRequiredService<IHandlerResolver>();
            var handler = await handlerResolver.ResolveAsync(response.Type);
            await handler.HandleAsync(response);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
