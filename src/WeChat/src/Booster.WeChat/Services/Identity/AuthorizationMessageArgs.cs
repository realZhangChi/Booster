using System;

namespace Booster.WeChat.Services.Identity
{
    public record AuthorizationMessageArgs
    {
        public bool IsSuccess { get; }

        public Exception? Exception { get; }

        public string? Message { get; }

        public int Code { get; }

        public static AuthorizationMessageArgs SuccessInstance() => new(true);

        public static AuthorizationMessageArgs FailedInstance(string message) => new(message);

        public static AuthorizationMessageArgs FailedInstance(string message, Exception? exception = null) =>
            new(message, exception);

        public static AuthorizationMessageArgs FailedInstance(int code, string message, Exception? exception = null) =>
            new(code, message, exception);

        private AuthorizationMessageArgs(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Code = isSuccess ? 0 : -1;
        }

        private AuthorizationMessageArgs(string message) : this(false)
        {
            Message = message;
        }

        private AuthorizationMessageArgs(string message, Exception? exception = null) : this(message)
        {
            Exception = exception;
        }

        private AuthorizationMessageArgs(int code, string message, Exception? exception = null) :
            this(message, exception)
        {
            Code = code;
        }
    }
}
