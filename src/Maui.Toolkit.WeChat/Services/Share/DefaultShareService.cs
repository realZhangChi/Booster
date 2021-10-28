using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Share;

namespace Maui.Toolkit.WeChat.Services.Share;

public class DefaultShareService : IShareService
{
    private readonly IShareHandler _shareHandler;

    public DefaultShareService(IShareHandler shareHandler, ShareScene scene)
    {
        _shareHandler = shareHandler;
    }

    public Task ShareImageAsync(ImageMessage message, ShareScene scene)
    {
        return _shareHandler.ShareImageAsync(message, scene);
    }

    public Task ShareMusicAsync(MusicMessage message, ShareScene scene)
    {
        return _shareHandler.ShareMusicAsync(message, scene);
    }

    public Task ShareTextAsync(TextMessage message, ShareScene scene)
    {
        return _shareHandler.ShareTextAsync(message, scene);
    }

    public Task ShareVideoAsync(VideoMessage message, ShareScene scene)
    {
        return _shareHandler.ShareVideoAsync(message, scene);
    }

    public Task ShareWebPageAsync(WebPageMessage message, ShareScene scene)
    {
        return _shareHandler.ShareWebPageAsync(message, scene);
    }
}
