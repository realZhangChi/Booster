using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Models.Share;

public class TextMessage : MediaMessageBase
{
    public string Text { get; private set; }

    public TextMessage(string title, string description, string text)
        : base(title, description)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentNullException(nameof(text));

        Text = text;
    }
}
