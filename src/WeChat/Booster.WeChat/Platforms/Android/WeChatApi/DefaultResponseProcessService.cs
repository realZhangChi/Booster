using Com.Tencent.MM.Opensdk.Modelbase;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultResponseProcessService : IResponseProcessService
    {
        private readonly IResponseProcessorResolver _responseProcessorResolver;

        public DefaultResponseProcessService(IResponseProcessorResolver responseProcessorResolver)
        {
            _responseProcessorResolver = responseProcessorResolver;
        }

        public async Task ProcessResponseAsync(BaseResp? response)
        {
            if (response is null)
                return;


            if (response.Err_Code is not BaseResp.IErrCode.ErrOk)
            {
                throw new NotImplementedException();
            }

            var processor = await _responseProcessorResolver.ResolveAsync(response.Type);
            await processor.ProcessResponseAsync(response);
        }
    }
}
