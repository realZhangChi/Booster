using Booster.WeChat.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Mocks
{
    internal class MockAuthorizationHandler : IAuthorizationHandler
    {
        public Task<bool> AuthorizeAsync()
        {
            return Task.FromResult(true);
        }
    }
}
