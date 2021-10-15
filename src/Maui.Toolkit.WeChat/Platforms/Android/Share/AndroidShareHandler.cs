using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Share;
using Maui.Toolkit.WeChat.Services.Share;

using IWeChatApi = Com.Tencent.MM.Opensdk.Openapi.IWXAPI;

namespace Maui.Toolkit.WeChat.Platforms.Android.Share;

public class AndroidShareHandler : IShareHandler
{
    private readonly IWeChatApi _weChatApi;

    public AndroidShareHandler(IWeChatApi weChatApi)
    {
        _weChatApi = weChatApi;
    }

    public Task ShareImageAsync(ImageMessage message)
    {
        throw new NotImplementedException();
    }

    public Task ShareMusicAsync(MusicMessage message)
    {
        throw new NotImplementedException();
    }

    public Task ShareTextAsync(TextMessage message)
    {
        throw new NotImplementedException();
    }

    public Task ShareVideoAsync(VideoMessage message)
    {
        throw new NotImplementedException();
    }

    public Task ShareWebPageAsync(WebPageMessage message)
    {
        throw new NotImplementedException();
    }
}
