namespace AdventOfCode2023._9_December;

public class Exercise17
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();
    
    public int GetResult()
    {
        var test = _puzzleInput
            .Select(x =>
                x.Split(" ")
                    .Select(int.Parse).ToList()).ToList();

        return test.Select(x => x.Last() + GetNextValue(x)).Sum();
    }

    private static int GetNextValue(IReadOnlyList<int> row)
    {
        var levelBelow = row.Skip(1)
            .Select((x, i) => x-row[i]).ToList();
        return levelBelow.All(x => x == levelBelow.First()) ? 
            levelBelow.Last() :
            levelBelow.Last() + GetNextValue(levelBelow);
    }
}