namespace AdventOfCode2023._1_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult() => _puzzleInput
            .Select(ConvertDigitToNumber)
            .Select(line => 
                line.ToList().Find(x => int.TryParse(x.ToString(), out _)).ToString() + 
                line.ToList().FindLast(x => int.TryParse(x.ToString(), out _)))
            .Aggregate(0, (sum, x) => int.TryParse(x, out var xInt) ? xInt+sum : sum);

    private static string ConvertDigitToNumber(string line) => line.
            Replace("one", "o1e")       // Since two ends with 0, we need to keep this
            .Replace("two", "t2")       // Since eight ends with t, we still need this
            .Replace("three", "t3e")    // Since eight ends with t, we still need this
            .Replace("four", "4")       // Since none ends with f we can remove the chars in front of 4 and since no numbers starts with t this can also be removed
            .Replace("five", "5e")      // Since eight starts with e we still need this.
            .Replace("six", "6")        // Same logic as 4
            .Replace("seven", "7n")     // since 9 starts with n we still need this
            .Replace("eight", "8")      // since 9 ends with e we still need this.
            .Replace("nine", "9");
}