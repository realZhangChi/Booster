using Booster.WeChat.Platforms.Android.WeChatApi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booster.WeChat.Extensions;
using Booster.WeChat.Test.Mock;
using Microsoft.Extensions.Options;
using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.WeChatApi
{
    public class AuthorizationResponseProcessor_Tests
    {
        [Fact]
        public async Task WeChatResponse_not_AuthResponse_Should_Throw()
        {
            var processor = new AuthorizationResponseProcessor(
                new MockAuthorizationService(),
                new OptionsWrapper<WeChatMobileOptions>(new WeChatMobileOptions()));
            var weChatResponse = new DummyWeChatResponse();

            await Assert.ThrowsAsync<ArgumentException>(() => processor.ProcessResponseAsync(weChatResponse));
        }

        [Fact]
        public async Task ProcessResponse_Should_Success()
        {
            var processor = new AuthorizationResponseProcessor(
                new MockAuthorizationService(),
                new OptionsWrapper<WeChatMobileOptions>(new WeChatMobileOptions()));
            var response = new Com.Tencent.MM.Opensdk.Modelmsg.SendAuth.Resp();

            await processor.ProcessResponseAsync(response);
        }

        class DummyWeChatResponse : Com.Tencent.MM.Opensdk.Modelbase.BaseResp
        {
            public override int Type => throw new NotImplementedException();

            public override bool CheckArgs()
            {
                throw new NotImplementedException();
            }
        }
    }
}
