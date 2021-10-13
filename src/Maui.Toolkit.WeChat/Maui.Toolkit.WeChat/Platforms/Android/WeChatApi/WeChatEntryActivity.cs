using System;
using System.Threading.Tasks;

using Android.Content;
using Android.OS;

using Com.Tencent.MM.Opensdk.Constants;
using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Modelmsg;
using Com.Tencent.MM.Opensdk.Openapi;

using Maui.Toolkit.WeChat.Extensions;
using Maui.Toolkit.WeChat.Services.Identity;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Maui;

namespace Maui.Toolkit.WeChat.Platforms.Android.WeChatApi;

public abstract class WeChatEntryActivity : MauiAppCompatActivity, IWXAPIEventHandler
{
    private readonly IWXAPI _wxApi;
    private readonly WeChatMobileOptions _options;

    public WeChatEntryActivity()
    {
        _wxApi = MauiApplication.Current.Services.GetRequiredService<IWXAPI>();
        _options = MauiApplication.Current.Services.GetRequiredService<IOptions<WeChatMobileOptions>>().Value;
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

        switch (response?.Err_Code)
        {
            case BaseResp.IErrCode.ErrOk:
                {
                    switch (response.Type)
                    {
                        case IConstantsAPI.CommandSendauth:
                            {
                                if (response is SendAuth.Resp authResponse)
                                {
                                    await AuthorizedAsync(authResponse.Code ?? string.Empty);
                                }
                                break;
                            }
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                }
            default:
                throw new NotImplementedException();
        }
    }

    protected virtual Task AuthorizedAsync(string code)
    {
        var authService = MauiApplication.Current.Services.GetRequiredService<IAuthorizationService>();
        return authService.AuthorizeCallbackAsync(_options.AppId, _options.AppSecret, code);
    }
}
