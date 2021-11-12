using System.Threading.Tasks;

namespace Booster.WeChat.Platforms.Android.WeChatApi
{
    public interface IResponseProcessorResolver
    {
        Task<IResponseProcessor> ResolveAsync(int responseType);
    }
}
