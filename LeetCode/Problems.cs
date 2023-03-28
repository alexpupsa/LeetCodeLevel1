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
    }
}
