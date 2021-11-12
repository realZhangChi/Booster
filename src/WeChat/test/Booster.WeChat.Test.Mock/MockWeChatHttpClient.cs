using Booster.WeChat.Services.Http;

using Microsoft.Extensions.Logging.Abstractions;

namespace Booster.WeChat.Test.Mock
{
    public class MockWeChatHttpClient : DefaultWeChatHttpClient
    {
        public static MockWeChatHttpClient SuccessInstance => new MockWeChatHttpClient(MockHttpClient.InstanceWithSuccessResponse);

        public static MockWeChatHttpClient FailInstance => new MockWeChatHttpClient(MockHttpClient.InstanceWithFailureResponse);

        public MockWeChatHttpClient(HttpClient httpClient) : base(httpClient, NullLogger<DefaultWeChatHttpClient>.Instance)
        {
        }
    }
}
