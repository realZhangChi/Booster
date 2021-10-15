using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Toolkit.WeChat.Models.Share;

namespace Maui.Toolkit.WeChat.Services.Share;

public interface IShareHandler
{
    Task ShareTextAsync(TextMessage message);

    Task ShareImageAsync(ImageMessage message);

    Task ShareMusicAsync(MusicMessage message);

    Task ShareVideoAsync(VideoMessage message);

    Task ShareWebPageAsync(WebPageMessage message);
}
