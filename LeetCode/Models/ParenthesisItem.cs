namespace LeetCode.Models;

public class ParenthesisItem
{
    public string? Value { get; set; }
    public int OpenCount { get; set; }
    public int CloseCount { get; set; }

    public ParenthesisItem(string value, int openCount, int closeCount)
    {
        this.Value = value;
        this.OpenCount = openCount;
        this.CloseCount = closeCount;
    }
}