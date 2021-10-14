using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Models.Share;

public abstract class MediaMessageBase
{
    public string? Title { get; set; }

    public string? Description { get; set; }
}
