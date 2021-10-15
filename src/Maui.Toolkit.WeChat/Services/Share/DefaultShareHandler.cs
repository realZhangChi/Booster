using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Share;

namespace Maui.Toolkit.WeChat.Services.Share;

public class DefaultShareHandler : IShareHandler
{
    public Task ShareImageAsync(ImageMessage message)
    {
        return Task.CompletedTask;
    }

    public Task ShareMusicAsync(MusicMessage message)
    {
        return Task.CompletedTask;
    }

    public Task ShareTextAsync(TextMessage message)
    {
        return Task.CompletedTask;
    }

    public Task ShareVideoAsync(VideoMessage message)
    {
        return Task.CompletedTask;
    }

    public Task ShareWebPageAsync(WebPageMessage message)
    {
        return Task.CompletedTask;
    }
}
