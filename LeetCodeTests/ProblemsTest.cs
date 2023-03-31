using FluentAssertions;
using LeetCode;

namespace LeetCodeTests
{
    public class ProblemsTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new[] { 1, 3, 6, 10 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 3, 1, 2, 10, 1 }, new[] { 3, 4, 6, 16, 17 })]
        public void RunningSum_Should_Return_Correct_Result(int[] input, int[] expected)
        {
            // Arrange

            // Act
            var result = Problems.RunningSum(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
        [InlineData(new int[] { 1, 2, 3 }, -1)]
        [InlineData(new int[] { 2, 1, -1 }, 0)]
        public void PivotIndex_Should_Return_Correct_Result(int[] input, int expected)
        {
            // Act
            var result = Problems.PivotIndex(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("egg", "add", true)]
        [InlineData("foo", "bar", false)]
        [InlineData("paper", "title", true)]
        public void IsIsomorphic_Should_Return_Correct_Result(string s, string t, bool expected)
        {
            // Act
            var result = Problems.IsIsomorphic(s, t);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("abc", "ahbgdc", true)]
        [InlineData("axc", "ahbgdc", false)]
        public void IsSubsequence_Should_Return_Correct_Result(string s, string t, bool expected)
        {
            // Act
            var result = Problems.IsSubsequence(s, t);

            // Assert
            result.Should().Be(expected);
        }
    }
}