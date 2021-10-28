using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Toolkit.WeChat.Models.Share;

public abstract class MediaMessageBase
{
    public string? Title { get; protected set; }

    public string? Description { get; protected set; }

    public MediaMessageBase(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
