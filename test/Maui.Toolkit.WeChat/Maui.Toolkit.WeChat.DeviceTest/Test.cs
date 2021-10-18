using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui;
using Xunit;
using FactAttribute = Microsoft.Maui.FactAttribute;

namespace Maui.Toolkit.WeChat.DeviceTest
{
    public class Test
    {
        [Fact]
        public void Should_Success()
        {
            Assert.Equal(0, 1);
        }
    }
}
