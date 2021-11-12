using System;

namespace Booster.WeChat.Services.Identity
{
    public record AuthorizationMessageArgs
    {
        public bool IsSuccess { get; }

        public Exception? Exception { get; }

        public string? Message { get; }

        public static AuthorizationMessageArgs SuccessInstance() => new(true);

        public static AuthorizationMessageArgs FailedInstance(string message) => new(message);

        public static AuthorizationMessageArgs FailedInstance(string message, Exception exception) =>
            new(message, exception);

        private AuthorizationMessageArgs(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        private AuthorizationMessageArgs(string message) : this(false)
        {
            Message = message;
        }

        private AuthorizationMessageArgs(string message, Exception exception) : this(message)
        {
            Exception = exception;
        }
    }
}
