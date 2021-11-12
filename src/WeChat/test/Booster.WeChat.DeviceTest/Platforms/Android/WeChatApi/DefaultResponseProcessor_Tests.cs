using System.Threading.Tasks;

using Booster.WeChat.Platforms.Android.WeChatApi;

using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.WeChatApi
{
    public class DefaultResponseProcessor_Tests : ResponseProcessorTestBase
    {
        public DefaultResponseProcessor_Tests()
        {
            Processor = new DefaultResponseProcessor();
        }

        [Fact]
        public async Task ProcessResponse_Should_Success()
        {
            var weChatResponse = new DummyWeChatResponse();

            await Processor.ProcessResponseAsync(weChatResponse);
        }
    }
}
