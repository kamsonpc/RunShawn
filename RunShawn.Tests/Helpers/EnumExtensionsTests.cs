using RunShawn.Core.Helpers.Enums;
using System.Collections.Generic;
using Xunit;

namespace RunShawn.Tests.Helpers
{
    public class EnumExtensionsTests
    {
        [Fact]
        public void EnumToDictionery()
        {
            var result = EnumUtil.ToDictionary<TestEnum>();

            var dictionary = new Dictionary<int, string>
            {
                { 1, "First" },
                { 2, "Second" },
                { 3, "Third" }
            };

            Assert.Equal(dictionary, result);
        }
    }

    public enum TestEnum
    {
        First = 1,
        Second = 2,
        Third = 3,
    }
}
