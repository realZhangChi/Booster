using Maui.Toolkit.WeChat.Models.Identity;
using Maui.Toolkit.WeChat.Services.Http;
using RichardSzalay.MockHttp;
using System;
using System.CodeDom;
using System.Net.Http;
using System.Text.Json;

namespace Maui.Toolkit.WeChat.Mocks
{
    public class MockHttpClient
    {
        private static string _token = @"
{
  ""access_token"": ""ACCESS_TOKEN"",
  ""expires_in"": 7200,
  ""refresh_token"": ""REFRESH_TOKEN"",
  ""openid"": ""OPENID"",
  ""scope"": ""SCOPE""
}
";
        private static string _userInfo = @"
{
  ""openid"": ""OPENID"",
  ""nickname"": ""NICKNAME"",
  ""sex"": 1,
  ""province"": ""PROVINCE"",
  ""city"": ""CITY"",
  ""country"": ""COUNTRY"",
  ""headimgurl"": ""https://thirdwx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0"",
  ""privilege"": [""PRIVILEGE1"", ""PRIVILEGE2""],
  ""unionid"": "" o6_bmasdasdsad6_2sgVt7hMZOPfL""
}
";

        public static HttpClient InstanceWithSuccessResponse => CreateMockHttpClient(true);

        public static HttpClient InstanceWithFailureResponse => CreateMockHttpClient(false);

        public static Token Token => JsonSerializer.Deserialize<Token>(_token)!;

        public static UserInfo UserInfo => JsonSerializer.Deserialize<UserInfo>(_userInfo)!;

        private MockHttpClient()
        {

        }

        private static HttpClient CreateMockHttpClient(bool withSuccess)
        {
            return withSuccess ? CreateHttpClientWithSuccess() : CreateHttpClientWithFailure();
        }

        private static HttpClient CreateHttpClientWithSuccess()
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler();

            mockHttpMessageHandler
                .When(DefaultWeChatHttpClient.BaseAddress + DefaultWeChatHttpClient.AccessTokenPath)
                .Respond("application/json", _token);
            mockHttpMessageHandler
                .When(DefaultWeChatHttpClient.BaseAddress + DefaultWeChatHttpClient.RefreshTokenPath)
                .Respond("application/json", _token);
            mockHttpMessageHandler
                .When(DefaultWeChatHttpClient.BaseAddress + DefaultWeChatHttpClient.UserInfoPath)
                .Respond("application/json", _userInfo);

            var httpClient = mockHttpMessageHandler.ToHttpClient();
            httpClient.BaseAddress = new Uri(DefaultWeChatHttpClient.BaseAddress);

            return httpClient;
        }

        private static HttpClient CreateHttpClientWithFailure()
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler();
            var errorResponse = @"
{
  ""errcode"": 1,
  ""errmsg"": ""WECHAT ERRORMESSAGE""
}";
            mockHttpMessageHandler
                .When($"{DefaultWeChatHttpClient.BaseAddress}/*")
                .Respond("application/json", errorResponse);

            var httpClient = mockHttpMessageHandler.ToHttpClient();
            httpClient.BaseAddress = new Uri(DefaultWeChatHttpClient.BaseAddress);

            return httpClient;
        }
    }
}
