using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booster.WeChat.DeviceTest.Tests
{
    public class Simple_Test
    {
        [Fact]
        public void Should_Success()
        {
            1.ShouldBe(1);
        }
    }
}
