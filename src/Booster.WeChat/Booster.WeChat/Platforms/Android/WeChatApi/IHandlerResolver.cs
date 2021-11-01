using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public interface IHandlerResolver
    {
        Task<IResponseHandler> ResolveAsync(int responseType);
    }
}
