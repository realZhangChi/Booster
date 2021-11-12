using Booster.WeChat.Services.Http;

using Microsoft.Extensions.Logging.Abstractions;

namespace Booster.WeChat.Test.Mock
{
    public class MockWeChatHttpClient : DefaultWeChatHttpClient
    {
        public MockWeChatHttpClient() : base(MockHttpClient.InstanceWithSuccessResponse, NullLogger<DefaultWeChatHttpClient>.Instance)
        {
        }
    }
}
