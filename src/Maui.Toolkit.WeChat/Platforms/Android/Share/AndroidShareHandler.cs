using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Share;
using Maui.Toolkit.WeChat.Services.Share;

using IWeChatApi = Com.Tencent.MM.Opensdk.Openapi.IWXAPI;
using WeChatRequest = Com.Tencent.MM.Opensdk.Modelmsg.SendMessageToWX.Req;

namespace Maui.Toolkit.WeChat.Platforms.Android.Share;

public class AndroidShareHandler : IShareHandler
{
    private readonly IWeChatApi _weChatApi;

    public AndroidShareHandler(IWeChatApi weChatApi)
    {
        _weChatApi = weChatApi;
    }

    public Task ShareImageAsync(ImageMessage message, ShareScene scene)
    {
        throw new NotImplementedException();
    }

    public Task ShareMusicAsync(MusicMessage message, ShareScene scene)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ShareTextAsync(TextMessage message, ShareScene scene)
    {
        var weChatMessage = message.ToNative();

        var request = new WeChatRequest()
        {
            Message = weChatMessage,
            Scene = (int)scene
        };

        return Task.FromResult(_weChatApi.SendReq(request));
    }

    public Task ShareVideoAsync(VideoMessage message, ShareScene scene)
    {
        throw new NotImplementedException();
    }

    public Task ShareWebPageAsync(WebPageMessage message, ShareScene scene)
    {
        throw new NotImplementedException();
    }
}
