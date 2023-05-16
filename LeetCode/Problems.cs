using LeetCode.Models;

namespace LeetCode
{
    public static class Problems
    {
        public static int[] RunningSum(int[] nums)
        {
            var output = new int[nums.Length];
            var sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                output[i] = sum;
            }

            return output;
        }

        public static int PivotIndex(int[] nums)
        {
            var left = 0;
            var right = nums.Sum();
            for (var i = 0; i < nums.Length; i++)
            {
                right -= nums[i];
                if (left == right)
                {
                    return i;
                }

                left += nums[i];
            }

            return -1;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            var characterMap = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (characterMap.ContainsKey(s[i]))
                {
                    if (characterMap[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (characterMap.ContainsValue(t[i]))
                    {
                        return false;
                    }

                    characterMap[s[i]] = t[i];
                }
            }

            return true;
        }

        public static bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var subStringIndex = 0;
            foreach (var t1 in t)
            {
                if (s[subStringIndex] == t1) subStringIndex++;
                if (subStringIndex == s.Length) return true;
            }

            return false;
        }

        public static ListNode? MergeTwoLists(ListNode list1, ListNode list2)
        {
            var current1 = list1;
            var current2 = list2;
            ListNode? startNode = null;
            ListNode? currentNode = null;
            while (current1 != null || current2 != null)
            {
                var nextValue = 0;
                if (current1 == null || current2?.val <= current1?.val)
                {
                    nextValue = current2?.val ?? 0;
                    current2 = current2?.next;
                }
                else if (current2 == null || current1?.val <= current2?.val)
                {
                    nextValue = current1?.val ?? 0;
                    current1 = current1?.next;
                }

                var nextNode = new ListNode(nextValue);
                if (startNode == null)
                {
                    startNode = nextNode;
                    currentNode = startNode;
                }
                else
                {
                    if (currentNode == null) continue;
                    currentNode.next = nextNode;
                    currentNode = currentNode.next;
                }
            }

            return startNode;
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            var list = new List<string>();
            var queue = new Queue<ParenthesisItem>();
            queue.Enqueue(new ParenthesisItem("(", 1, 0));
            while (queue.Any())
            {
                var item = queue.Dequeue();
                if (item.Value?.Length == n * 2)
                {
                    list.Add(item.Value);
                    continue;
                }

                if (item.OpenCount > item.CloseCount && item.CloseCount < n)
                {
                    queue.Enqueue(new ParenthesisItem(string.Concat(item.Value, ")"), item.OpenCount,
                        item.CloseCount + 1));
                }

                if (item.OpenCount < n)
                {
                    queue.Enqueue(new ParenthesisItem(string.Concat(item.Value, "("), item.OpenCount + 1,
                        item.CloseCount));
                }
            }

            return list.Distinct().ToList();
        }

        public static ListNode? MergeKLists(ListNode?[] lists)
        {
            var nodes = lists.ToList();
            var mainIndex = GetLowestNodeIndex(nodes);
            if (mainIndex == -1) return null;

            var main = nodes[mainIndex];
            var full = main;
            var current = full;
            while (main != null)
            {
                nodes[mainIndex] = null;
                if (main.next != null)
                {
                    nodes.Add(main.next);
                }

                mainIndex = GetLowestNodeIndex(nodes);
                if (mainIndex == -1) break;
                main = nodes[mainIndex];
                current!.next = main;
                current = current.next;
            }

            return full;
        }

        public static ListNode? SwapPairs(ListNode? head)
        {
            if (head == null) return null;

            var current = head;
            ListNode? previous = null;
            var firstIteration = true;

            while (current?.next != null)
            {
                var second = current.next;
                var third = second.next;
                if (firstIteration)
                {
                    head = second;
                    firstIteration = false;
                }

                current.next.next = current;
                current.next = third;
                if (previous != null)
                {
                    previous.next = second;
                }

                previous = current;
                current = third;
            }

            return head;
        }

        public static ListNode? ReverseKGroup(ListNode? head, int k)
        {
            if (head == null) return null;

            var previous = new ListNode
            {
                next = head
            };
            var current = previous.next;
            head = previous;

            while (current != null)
            {
                var count = 0;
                var last = current;
                var nodeList = new List<ListNode?>();
                while (count < k && last != null)
                {
                    nodeList.Add(last);
                    count++;
                    last = last?.next;
                }

                if (count < k) break;

                current = nodeList.LastOrDefault()?.next;
                nodeList.Reverse();
                var root = nodeList.First();
                var currentInGroup = root;
                foreach (var listNode in nodeList.Skip(1))
                {
                    currentInGroup!.next = listNode;
                    currentInGroup = currentInGroup.next;
                }

                currentInGroup!.next = current;
                previous!.next = root;
                previous = currentInGroup;
            }

            return head?.next;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            var overwriteIndex = 0;
            var startOverwrite = false;
            var countDuplicate = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    if (!startOverwrite)
                    {
                        overwriteIndex = i;
                    }

                    startOverwrite = true;
                    countDuplicate++;
                }
                else
                {
                    if (startOverwrite)
                    {
                        nums[overwriteIndex] = nums[i];
                        overwriteIndex++;
                    }
                }
            }

            return nums.Length - countDuplicate;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            var overwriteIndex = 0;
            var startOverwrite = false;
            var countVal = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    if (!startOverwrite)
                    {
                        overwriteIndex = i;
                    }

                    startOverwrite = true;
                    countVal++;
                }
                else
                {
                    if (startOverwrite)
                    {
                        nums[overwriteIndex] = nums[i];
                        overwriteIndex++;
                    }
                }
            }

            return nums.Length - countVal;
        }

        private static int GetLowestNodeIndex(List<ListNode?> lists)
        {
            var minValue = 10000;
            var foundIndex = -1;
            for (var i = 0; i < lists.Count; i++)
            {
                if (lists[i] == null || lists[i]?.val >= minValue) continue;
                minValue = lists[i]?.val ?? 0;
                foundIndex = i;
            }

            return foundIndex;
        }
    }
}