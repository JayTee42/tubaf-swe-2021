using System;
using System.Collections.Generic;
using Xunit;
using SetCollection;

// Note: These are just my example tests.
// Be creative and design some for yourselves :)

namespace Tests
{
    public class UnitTests
    {
        // Note: Assert.Equal on collections works by getting enumerators for both
        // and comparing them element-by-element. That is not what we want
        // as our enumeration order is undefined!
        private static void AssertSetsEqual<T>(Set<T> s1, Set<T> s2) => Assert.True(s1.Equals(s2));

        [Fact]
        public void TestEmpty()
        {
            var set = new Set<int>();
            Assert.Empty(set);
        }

        [Fact]
        public void TestUniqueElements()
        {
            var set = new Set<int>();

            set.Add(42);
            set.Add(8);
            set.Add(42);

            Assert.Equal(2, set.Count);
        }

        [Theory]
        [InlineData(new int[] { }, new int[] { }, true)]
        [InlineData(new int[] { }, new int[] { 42 }, false)]
        [InlineData(new int[] { 42, 42, 66 }, new int[] { 66, 42 }, true)]
        [InlineData(new int[] { 42, 42, 66, 99 }, new int[] { 99, 66, 99, 42, 99 }, true)]
        [InlineData(new int[] { 42, 42, 99 }, new int[] { 99, 66, 99, 42, 99 }, false)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, true)]
        public void TestEqualsHashCode(IEnumerable<int> first, IEnumerable<int> sec, bool exp)
        {
            var firstSet = new Set<int>(first);
            var secondSet = new Set<int>(sec);

            Assert.Equal(exp, firstSet.Equals(secondSet));

            // If the sets are equal, their hash codes must be equal, too:
            if (exp)
            {
                Assert.Equal(firstSet.GetHashCode(), secondSet.GetHashCode());
            }
        }

        [Theory]
        [InlineData(new int[] { 42, 42, 66 }, new int[] { 66, 17 }, new int[] { 66 })]
        [InlineData(new int[] { 42 }, new int[] { 66 }, new int[] { })]
        [InlineData(new int[] { 42 }, new int[] { 42 }, new int[] { 42 })]
        [InlineData(new int[] { 17, 42, 42, 66 }, new int[] { 66, 17 }, new int[] { 66, 17 })]
        public void TestIntersect(IEnumerable<int> first, IEnumerable<int> sec, IEnumerable<int> exp)
        {
            // Execute the intersection operation:
            var firstSet = new Set<int>(first);
            var secondSet = new Set<int>(sec);
            var intersectSet = firstSet.Intersect(secondSet);

            // Validate it:
            var expSet = new Set<int>(exp);
            AssertSetsEqual(expSet, intersectSet);
        }

        [Theory]
        [InlineData(new int[] { 42, 42, 66 }, new int[] { 66, 17 }, new int[] { 42 })]
        [InlineData(new int[] { 42 }, new int[] { 66 }, new int[] { 42 })]
        [InlineData(new int[] { 42 }, new int[] { 42 }, new int[] { })]
        [InlineData(new int[] { 17, 42, 42, 66 }, new int[] { 66, 17 }, new int[] { 42 })]
        public void TestDifference(IEnumerable<int> first, IEnumerable<int> sec, IEnumerable<int> exp)
        {
            // Execute the difference operation:
            var firstSet = new Set<int>(first);
            var secondSet = new Set<int>(sec);
            var diffSet = firstSet.Subtract(secondSet);

            // Validate it:
            var expSet = new Set<int>(exp);
            AssertSetsEqual(expSet, diffSet);
        }
    }
}
