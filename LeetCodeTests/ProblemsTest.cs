using FluentAssertions;
using LeetCode;
using LeetCode.Models;

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

        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        [InlineData(new int[] { }, new int[] { }, new int[] { })]
        [InlineData(new int[] { }, new int[] { 0 }, new int[] { 0 })]
        public void MergeTwoLists_Should_Return_Correct_Result(int[] list1, int[] list2, int[] expected)
        {
            // Arrange
            var ll1 = GenerateLinkedList(list1);
            var ll2 = GenerateLinkedList(list2);
            var llExpected = GenerateLinkedList(expected);

            // Act
            var result = Problems.MergeTwoLists(ll1, ll2);

            // Assert
            result.Should().BeEquivalentTo(llExpected);
        }

        private static ListNode GenerateLinkedList(int[] input)
        {
            ListNode startNode = null;
            ListNode currentNode = null;
            for (var i = 0; i < input.Length; i++)
            {
                var node = new ListNode(input[i]);
                if (startNode == null)
                {
                    startNode = node;
                    currentNode = startNode;
                }
                else
                {
                    currentNode.next = node;
                    currentNode = currentNode.next; 
                }
            }

            return startNode;
        }
    }
}