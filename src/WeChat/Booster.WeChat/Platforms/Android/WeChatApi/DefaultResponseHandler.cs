using System.Threading.Tasks;

using Com.Tencent.MM.Opensdk.Constants;
using Com.Tencent.MM.Opensdk.Modelbase;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public class DefaultResponseHandler : IResponseHandler
    {
        public int ResponseType => IConstantsAPI.CommandUnknown;

        public Task HandleAsync(BaseResp response)
        {
            return Task.CompletedTask;
        }
    }
}
