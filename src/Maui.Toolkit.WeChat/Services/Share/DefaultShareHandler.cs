using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Share;

namespace Maui.Toolkit.WeChat.Services.Share;

public class DefaultShareHandler : IShareHandler
{
    public Task ShareImageAsync(ImageMessage message, ShareScene scene)
    {
        return Task.CompletedTask;
    }

    public Task ShareMusicAsync(MusicMessage message, ShareScene scene)
    {
        return Task.CompletedTask;
    }

    public Task<bool> ShareTextAsync(TextMessage message, ShareScene scene)
    {
        return Task.FromResult(false);
    }

    public Task ShareVideoAsync(VideoMessage message, ShareScene scene)
    {
        return Task.CompletedTask;
    }

    public Task ShareWebPageAsync(WebPageMessage message, ShareScene scene)
    {
        return Task.CompletedTask;
    }
}
