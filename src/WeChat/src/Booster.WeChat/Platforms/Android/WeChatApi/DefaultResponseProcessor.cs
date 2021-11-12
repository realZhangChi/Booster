using System.Threading.Tasks;

using Com.Tencent.MM.Opensdk.Constants;
using Com.Tencent.MM.Opensdk.Modelbase;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultResponseProcessor : ResponseProcessorBase, IResponseProcessor
    {
        public int ResponseType => IConstantsAPI.CommandUnknown;

        public Task ProcessResponseAsync(BaseResp response)
        {
            if (!EnsureSuccessResponse(response))
            {
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
