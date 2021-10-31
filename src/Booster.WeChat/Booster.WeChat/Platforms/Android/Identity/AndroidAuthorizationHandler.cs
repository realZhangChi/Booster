using System.Threading.Tasks;

using Com.Tencent.MM.Opensdk.Modelmsg;
using Com.Tencent.MM.Opensdk.Openapi;

using Booster.WeChat.Services.Identity;

namespace Booster.WeChat.Platforms.Android.Identity;

public class AndroidAuthorizationHandler : IAuthorizationHandler
{
    private readonly IWXAPI _wxApi;

    public AndroidAuthorizationHandler(IWXAPI wxApi)
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
