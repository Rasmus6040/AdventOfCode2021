namespace AdventOfCode2024._7_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        long correct = 0;
        foreach (var puzzleLine in _puzzleInput.Select(x => x.Split(": ")))
        {
            long expectedResult = long.Parse(puzzleLine[0]);
            var numbers = puzzleLine[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var memory = new Dictionary<(int, long), bool>();
            if (CanAchieveResult(numbers, 1, numbers[0], expectedResult, memory))
            {
                correct += expectedResult;
            }
        }
        return correct;
    }

    static bool CanAchieveResult(List<int> numbers, int index, long current, long target, Dictionary<(int, long), bool> memo)
    {
        if (index == numbers.Count)
        {
            return current == target;
        }

        var state = (index, current);
        if (memo.TryGetValue(state, out bool cachedResult))
        {
            return cachedResult;
        }

        long nextNum = numbers[index];

        if (current > target)
        {
            memo[state] = false;
            return false;
        }

        // Try addition
        bool addResult = CanAchieveResult(numbers, index + 1, current + nextNum, target, memo);

        // Try multiplication
        bool mulResult = CanAchieveResult(numbers, index + 1, current * nextNum, target, memo);

        bool result = addResult || mulResult;
        memo[state] = result;
        return result;
    }

}