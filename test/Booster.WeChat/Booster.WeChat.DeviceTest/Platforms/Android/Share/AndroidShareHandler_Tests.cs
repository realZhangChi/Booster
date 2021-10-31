using System.Threading.Tasks;

using Booster.WeChat.Services.Share;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;

using Shouldly;

using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.Share
{
    public class AndroidShareHandler_Tests
    {
        [Fact]
        public async Task ShareText_Should_Return_False()
        {
            var service = MauiApplication.Current.Services.GetRequiredService<IShareHandler>();
            var message = new Models.Share.TextMessage("Title", "Description", "Text");

            var result = await service.ShareTextAsync(message, Models.Share.ShareScene.Session);

            result.ShouldBeFalse();
        }
    }
}
