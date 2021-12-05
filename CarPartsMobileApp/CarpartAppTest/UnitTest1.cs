using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Xunit; 

namespace CarpartAppTest
{
    [TestClass]
    public class UnitTest1
    {
        //[Fact]
        public class Tests
        {
            [Fact]
            public void ThisShouldPass()
            {
                Xunit.Assert.True(true);
            }

            [Fact]
            public async Task ThisShouldFail()
            {
                await Task.Run(() => { throw new Exception("hello"); });
            }
        }

    }
}
