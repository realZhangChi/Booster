using System;
using System.Threading.Tasks;
using Xunit;

namespace Maui.Toolkit.WeChat.Models.Share
{
    public class TextMessage_Tests
    {
        [Fact]
        public async Task Text_Should_Not_Be_Null()
        {
            var title = "Title";
            var description = "Description";

            await Assert.ThrowsAsync<ArgumentNullException>(() => Task.Run(() => new TextMessage(title, description, null!)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => Task.Run(() => new TextMessage(title, description, string.Empty)));
        }
    }
}
