using Com.Tencent.MM.Opensdk.Modelbase;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultResponseManager : IResponseManager
    {
        private readonly IResponseProcessorResolver _responseProcessorResolver;

        public DefaultResponseManager(IResponseProcessorResolver responseProcessorResolver)
        {
            _responseProcessorResolver = responseProcessorResolver;
        }

        public async Task HandleAsync(BaseResp? response)
        {
            if (response is null)
                return;

            var processor = await _responseProcessorResolver.ResolveAsync(response.Type);
            await processor.HandleAsync(response);
        }
    }
}
