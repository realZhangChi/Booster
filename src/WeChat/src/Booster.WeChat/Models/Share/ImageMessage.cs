﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Models.Share;

public class ImageMessage : MediaMessageBase
{
    public ImageMessage(string title, string description) : base(title, description)
    {
    }
}
