using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Booster.WeChat.Models.Share;

namespace Booster.WeChat.Services.Share;

public interface IShareService
{
    Task ShareTextAsync(TextMessage message, ShareScene scene);

    Task ShareImageAsync(ImageMessage message, ShareScene scene);

    Task ShareMusicAsync(MusicMessage message, ShareScene scene);

    Task ShareVideoAsync(VideoMessage message, ShareScene scene);

    Task ShareWebPageAsync(WebPageMessage message, ShareScene scene);
}
