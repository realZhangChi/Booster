using System.Threading.Tasks;

using Com.Tencent.MM.Opensdk.Modelbase;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public interface IResponseHandler
    {
        public int ResponseType { get; }

        Task HandleAsync(BaseResp response);
    }
}
