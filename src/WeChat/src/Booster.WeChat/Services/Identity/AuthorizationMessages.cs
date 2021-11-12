namespace Booster.WeChat.Services.Identity
{
    public class AuthorizationMessages
    {
        public static string Success => typeof(AuthorizationMessages).FullName + "." + nameof(Success);

        public static string Failed => typeof(AuthorizationMessages).FullName + "." + nameof(Failed);
    }
}
