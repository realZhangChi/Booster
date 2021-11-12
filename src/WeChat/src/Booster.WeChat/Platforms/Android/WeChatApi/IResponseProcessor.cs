using System.Threading.Tasks;

using Com.Tencent.MM.Opensdk.Modelbase;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public interface IResponseProcessor
    {
        public int ResponseType { get; }

        Task ProcessResponseAsync(BaseResp? response);
    }
}
