using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Booster.WeChat.Platforms.Android.WeChatApi;

using Xunit;

namespace Booster.WeChat.DeviceTest.Platforms.Android.WeChatApi
{
    public class DefaultResponseProcessor_Tests
    {
        [Fact]
        public async Task ProcessResponse_Should_Success()
        {
            var processor = new DefaultResponseProcessor();

            await processor.ProcessResponseAsync((Com.Tencent.MM.Opensdk.Modelbase.BaseResp)null);
        }
    }
}
