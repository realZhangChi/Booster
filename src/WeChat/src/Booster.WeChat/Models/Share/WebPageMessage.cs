using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Models.Share;

public class WebPageMessage : MediaMessageBase
{
    public WebPageMessage(string title, string description) : base(title, description)
    {
    }

    public string? WebPageUrl { get; set; }
}
