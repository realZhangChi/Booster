using System.Threading.Tasks;

using Com.Tencent.MM.Opensdk.Constants;
using Com.Tencent.MM.Opensdk.Modelbase;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultResponseProcessor : IResponseProcessor
    {
        public int ResponseType => IConstantsAPI.CommandUnknown;

        public Task ProcessResponseAsync(BaseResp response)
        {
            return Task.CompletedTask;
        }
    }
}
