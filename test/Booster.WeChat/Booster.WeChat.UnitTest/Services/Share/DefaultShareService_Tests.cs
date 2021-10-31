using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Booster.WeChat.Models.Share;

using Shouldly;

using Xunit;

namespace Booster.WeChat.Services.Share
{
    public class DefaultShareService_Tests
    {
        [Fact]
        public async Task ShareText_Should_Success()
        {
            var message = new TextMessage("Title", "Description", "Text");
            var sence = ShareScene.Session;
            var shareHandler = new DefaultShareHandler();
            var shareService = new DefaultShareService(shareHandler);

            bool result = await shareService.ShareTextAsync(message, sence);

            result.ShouldBeFalse();
        }
    }
}
