namespace AdventOfCode2023._5_December;

public static class Exercise9
{
    public static long GetResult()
    {
        var puzzleInput = PuzzleInput.Get();
        var seeds = puzzleInput
            .First()
            .Split(": ")
            .Last()
            .Split(" ")
            .Select(long.Parse);

        var rules = new List<List<(long, long, long)>> { new() };
        foreach (var line in puzzleInput.Skip(2))
        {
            if (string.IsNullOrEmpty(line))
            {
                rules.Add(new List<(long, long, long)>());
                continue;
            }

            if (line.Contains(':')) continue;
            var parts = line.Split(" ").Select(long.Parse).ToArray();
            rules.Last().Add((parts[1], parts[0], parts[2]));
        }

        return seeds
            .Select(seed => rules.Aggregate(seed, (current, ruleSet) =>
                ruleSet.FirstOrDefault(item => item.Item1 <= current && current < item.Item1 + item.Item3) is var rule 
                    && rule != default ? 
                        current + (rule.Item2 - rule.Item1) : 
                        current))
            .Min();
    }
}