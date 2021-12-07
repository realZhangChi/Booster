using Booster.WeChat.Services.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booster.WeChat.Binding.iOS;

namespace Booster.WeChat.Platforms.iOS.Identity
{
    internal class iOSAuthorizer : IPlatformAuthorizer
    {
        public Task<bool> AuthorizeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
