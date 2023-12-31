namespace AdventOfCode2023._1_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var values = _puzzleInput.Select(line => 
            line.ToList().Find(x => int.TryParse(x.ToString(), out _)).ToString() + 
            line.ToList().FindLast(x => int.TryParse(x.ToString(), out _)))
            .Aggregate(0, (sum, x) => int.TryParse(x, out var xInt) ? xInt+sum : sum);
        return values;
    }    
}