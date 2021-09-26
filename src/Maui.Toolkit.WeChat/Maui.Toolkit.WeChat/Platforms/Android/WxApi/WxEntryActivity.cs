using Android.Content;
using Android.OS;
using Com.Tencent.MM.Opensdk.Constants;
using Com.Tencent.MM.Opensdk.Modelbase;
using Com.Tencent.MM.Opensdk.Modelmsg;
using Com.Tencent.MM.Opensdk.Openapi;
using Maui.Toolkit.WeChat.Services.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using System;
using System.Threading.Tasks;
using static Com.Tencent.MM.Opensdk.Modelbase.BaseResp;

namespace Maui.Toolkit.WeChat.Platforms.Android.WxApi;

public abstract class WxEntryActivity : MauiAppCompatActivity, IWXAPIEventHandler
{
    private readonly IWXAPI _wxApi;

    public WxEntryActivity()
    {
        _wxApi = MauiApplication.Current.Services.GetRequiredService<IWXAPI>();
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }

    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);
        _wxApi.HandleIntent(intent, this);
    }

    public void OnReq(BaseReq p0)
    {
        throw new NotImplementedException();
    }

    public async void OnResp(BaseResp response)
    {
        switch (response.Err_Code)
        {
            case ErrCode.ErrOk:
                {
                    switch (response.Type)
                    {
                        case ConstantsAPI.CommandSendauth:
                            {
                                await AuthorizedAsync((response as SendAuth.Resp).Code);
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
        return authService.AuthorizedAsync(code);
    }
}
