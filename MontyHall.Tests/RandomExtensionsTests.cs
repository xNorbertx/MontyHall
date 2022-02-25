using MontyHall.Core.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace MontyHall.Tests
{
    public class RandomExtensionsTests
    {
        [Theory]
        [MemberData(nameof(DataHappyFlow))]
        public void TestNextExcept_HappyFlow(int maxValue, List<int> exceptList)
        {
            var random = new Random();
            var res = random.NextExcept(maxValue, exceptList);

            Assert.DoesNotContain(res, exceptList);
            Assert.True(res <= maxValue);
        }

        [Theory]
        [MemberData(nameof(DataNonHappyFlow))]
        public void TestNextExcept_NonHappyFlow(int maxValue, List<int> exceptList)
        {
            var random = new Random();

            try
            {
                var dummy = random.NextExcept(maxValue, exceptList);
            }
            catch (Exception e)
            {                
                Assert.IsType<ArgumentException>(e);
            }
        }

        public static IEnumerable<object[]> DataHappyFlow()
        {
            var list1 = new List<int>() { 1 }; 
            var list2 = new List<int>() { 0, 2, };
            var list3 = new List<int>() { 0, 1, }; 
            var list4 = new List<int>() { 0, 1, 2, 3, 4, 5 };
            return new List<object[]>
            {
                    new object[] { 3, list1 },
                    new object[] { 3, list2 },
                    new object[] { 3, list3 },
                    new object[] { 10, list4 },
            };
        }

        public static IEnumerable<object[]> DataNonHappyFlow()
        {
            var list1 = new List<int>() { 0, 1 };
            var list2 = new List<int>() { 0, 1, 2 };
            var list3 = new List<int>() { 0, 1, 2, 3 };
            var list4 = new List<int>() { 0, 1, 2, 3, 4, 5 };
            return new List<object[]>
            {
                    new object[] { 1, list1 },
                    new object[] { 2, list2 },
                    new object[] { 3, list3 },
                    new object[] { 5, list4 },
            };
        }
    }
}
