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

        [Theory]
        [InlineData(1, new string[] { "()" })]
        [InlineData(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
        public void GenerateParenthesis_Should_Return_Correct_Result(int input, string[] expected)
        {
            // Act
            var result = Problems.GenerateParenthesis(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(
            new int[] { 1, 1, 2, 3, 4, 4, 5, 6 },
            new int[] { 1, 4, 5 }, new int[] { 1, 3, 4 }, new int[] { 2, 6 })]
        [InlineData(new int[] { })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { -1, 2 }, new int[] { 2 }, new int[] { }, new int[] { -1 })]
        public void MergeKLists_Should_Return_Correct_Result(int[] expected, params int[][] input)
        {
            // Act
            var result = Problems.MergeKLists(input.Select(GenerateLinkedList).ToArray());
            var llExpected = GenerateLinkedList(expected);

            // Assert
            result.Should().BeEquivalentTo(llExpected);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 2, 1, 4, 3 })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        public void SwapPairs_Should_Return_Correct_Result(int[] list, int[] expected)
        {
            // Arrange
            var ll = GenerateLinkedList(list);
            var llExpected = GenerateLinkedList(expected);

            // Act
            var result = Problems.SwapPairs(ll);

            // Assert
            result.Should().BeEquivalentTo(llExpected);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 2, 1, 4, 3, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 3, 2, 1, 4, 5 })]
        [InlineData(new int[] { 1 }, 2, new int[] { 1 })]
        public void ReverseKGroup_Should_Return_Correct_Result(int[] list, int k, int[] expected)
        {
            // Arrange
            var ll = GenerateLinkedList(list);
            var llExpected = GenerateLinkedList(expected);

            // Act
            var result = Problems.ReverseKGroup(ll, k);

            // Assert
            result.Should().BeEquivalentTo(llExpected);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new int[] { 0, 1, 2, 3, 4 }, 5)]
        public void RemoveDuplicates_Should_Return_Correct_Result(int[] list, int[] expectedList, int expectedCount)
        {
            // Arrange

            // Act
            var result = Problems.RemoveDuplicates(list);

            // Assert
            list.Should().StartWith(expectedList);
            result.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 2, 3 }, 3, new int[] { 2, 2 }, 2)]
        [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new int[] { 0, 1, 4, 0, 3 }, 5)]
        public void RemoveElement_Should_Return_Correct_Result(int[] list, int value, int[] expectedList, int expectedCount)
        {
            // Arrange

            // Act
            var result = Problems.RemoveElement(list, value);

            // Assert
            list.Take(expectedCount).Should().BeEquivalentTo(expectedList);
            result.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData("sadbutsad", "sad", 0)]
        [InlineData("leetcode", "leeto", -1)]
        [InlineData("aaa", "aaaa", -1)]
        [InlineData("mississippi", "issip", 4)]
        [InlineData("mississippi", "pi", 9)]
        public void StrStr_Should_Return_Correct_Result(string haystack, string needle, int expectedIndex)
        {
            // Arrange

            // Act
            var result = Problems.StrStr(haystack, needle);

            // Assert
            result.Should().Be(expectedIndex);
        }

        [Theory]
        [InlineData(10, 3, 3)]
        [InlineData(7, -3, -2)]
        [InlineData(1, 1, 1)]
        [InlineData(-2147483648, -1, 2147483647)]
        [InlineData(-2147483648, 1, -2147483648)]
        public void Divide_Should_Return_Correct_Result(int divident, int divisor, int expectedResult)
        {
            // Arrange

            // Act
            var result = Problems.Divide(divident, divisor);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("barfoothefoobarman", new string[] { "foo", "bar" }, new int[] { 0, 9 })]
        [InlineData("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" }, new int[] { })]
        [InlineData("barfoofoobarthefoobarman", new string[] { "bar", "foo", "the" }, new int[] { 6, 9, 12 })]
        [InlineData("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "good" }, new int[] { 8 })]
        [InlineData("lingmindraboofooowingdingbarrwingmonkeypoundcake", new string[] { "fooo", "barr", "wing", "ding", "wing" }, new int[] { 13 })]
        [InlineData("aaaaaaaaaaaaaa", new string[] { "aa", "aa" }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData("dddddddddddd", new string[] { "dddd", "dddd" }, new int[] { 0, 1, 2, 3, 4 })]
        public void FindSubstring_Should_Return_Correct_Result(string input, string[] words, int[] expectedResult)
        {
            // Arrange

            // Act
            var result = Problems.FindSubstring(input, words);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [InlineData(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 1, 5 }, new int[] { 1, 5, 1 })]
        [InlineData(new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 })]

        public void NextPermutation_Should_Return_Correct_Result(int[] nums, int[] expectedResult)
        {
            // Arrange

            // Act
            Problems.NextPermutation(nums);

            // Assert
            nums.Should().BeEquivalentTo(expectedResult, o => o.WithStrictOrdering());
        }

        private static ListNode GenerateLinkedList(int[] input)
        {
            ListNode? startNode = null;
            ListNode? currentNode = null;
            foreach (var t in input)
            {
                var node = new ListNode(t);
                if (startNode == null)
                {
                    startNode = node;
                    currentNode = startNode;
                }
                else
                {
                    if (currentNode == null) continue;
                    currentNode.next = node;
                    currentNode = currentNode.next;
                }
            }

            return startNode.As<ListNode>();
        }
    }
}