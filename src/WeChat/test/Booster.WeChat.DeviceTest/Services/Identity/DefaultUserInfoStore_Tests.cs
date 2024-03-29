﻿using Booster.WeChat.Services.Identity;
using Booster.WeChat.Models.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Microsoft.Maui.Essentials;

namespace Booster.WeChat.DeviceTest.Services.Identity
{
    public class DefaultUserInfoStore_Tests
    {
        [Fact]
        public async Task Should_Get_Null_Default()
        {
            SecureStorage.RemoveAll();
            var _userInfoStore = new DefaultUserInfoStore();
            var token = await _userInfoStore.GetOrNullAsync();

            token.ShouldBeNull();
        }

        [Fact]
        public async Task Null_UserInfo_Should_Throw()
        {
            var _userInfoStore = new DefaultUserInfoStore();
            UserInfo userInfo = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => _userInfoStore.SetAsync(userInfo));
        }

        [Fact]
        public async void Should_Set_And_Get_UserInfo()
        {
            var _userInfoStore = new DefaultUserInfoStore();
            var userInfo = new UserInfo(
                "OPENID",
                "NICKNAME",
                Sex.Male,
                "COUNTRY",
                "PROVINCE",
                "CITY",
                "HEADIMGURL",
                new List<string> { "PRIVILEGE" },
                "UNIONID");

            await _userInfoStore.SetAsync(userInfo);

            var result = await _userInfoStore.GetOrNullAsync();
            result.ShouldBeEquivalentTo(userInfo);
        }
    }
}
