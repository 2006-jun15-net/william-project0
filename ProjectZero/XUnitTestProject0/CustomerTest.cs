using ProjectZero.Library.RunnerClasses;
using System;
using Xunit;

namespace XUnitTestProject0
{
    public class CustomerTest
    {
        [Fact]
        public void TestDisplayCustomers()
        {
            CustomerRunner.DisplayCustomers();
        }
    }
}
