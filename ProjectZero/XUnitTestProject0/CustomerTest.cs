using ProjectZero.Library.RunnerClasses;
using ProjectZero.Library;
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
        [Fact]
        public void TestDisplayOrderHistory()
        {
            // Display by store name
            StoreRunner.GetStoreHistoryByName("reddit");
        }
        [Fact]
        public void TestDisplayOrders()
        {
            OrderRunner.DisplayOrders();
        }
        [Fact]
        public void TestSplit()
        {
            string[] tokens = CustomerRunner.SplitGetFirstAndLast("First Last");
            Assert.True(tokens[0].ToLower() == "first");
            Assert.True(tokens[1].ToLower() == "last");
        }
    }
}
