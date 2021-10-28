using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Share;

namespace Maui.Toolkit.WeChat.Services.Share;

public interface IShareHandler
{
    Task<bool> ShareTextAsync(TextMessage message, ShareScene scene);

    Task ShareImageAsync(ImageMessage message, ShareScene scene);

    Task ShareMusicAsync(MusicMessage message, ShareScene scene);

    Task ShareVideoAsync(VideoMessage message, ShareScene scene);

    Task ShareWebPageAsync(WebPageMessage message, ShareScene scene);
}
