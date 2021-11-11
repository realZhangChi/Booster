using System.Threading.Tasks;

using Com.Tencent.MM.Opensdk.Modelmsg;
using Com.Tencent.MM.Opensdk.Openapi;

using Booster.WeChat.Services.Identity;

namespace Booster.WeChat.Platforms.Android.Identity;

public class AndroidAuthorizer : IPlatformAuthorizer
{
    private readonly IWXAPI _wxApi;

    public AndroidAuthorizer(IWXAPI wxApi)
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
