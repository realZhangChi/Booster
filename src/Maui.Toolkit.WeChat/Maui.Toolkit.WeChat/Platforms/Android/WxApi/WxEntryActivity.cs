namespace Maui.Toolkit.WeChat.Platforms.Android.WxApi;

public abstract class WxEntryActivity : MauiAppCompatActivity, IWXAPIEventHandler
{
    private readonly IWXAPI _wxApi;

    public WxEntryActivity()
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
        return authService.AuthorizeCallbackAsync(code);
    }
}
