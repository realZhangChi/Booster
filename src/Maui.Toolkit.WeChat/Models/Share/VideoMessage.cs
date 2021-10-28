using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Models.Share;

public class VideoMessage : MediaMessageBase
{
    public VideoMessage(string title, string description) : base(title, description)
    {
    }

    public string? Url { get; set; }

    public string? LowBandwidthUrl { get; set; }
}
