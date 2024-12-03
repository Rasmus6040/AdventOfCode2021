namespace AdventOfCode2024._2_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var puzzleInput = _puzzleInput.Select(x => x.Split(" ").Select(int.Parse).ToList())
            .ToList();
        return puzzleInput.Count(x => 
            x.Aggregate(x.First()-1, (last, next) => last == -1 ? -1 : (last < next && next-last < 4) ? next : -1) != -1 || 
            x.Aggregate(x.First()+1, (last, next) => last == int.MaxValue ? int.MaxValue : (last > next && last-next < 4) ? next : int.MaxValue) != int.MaxValue);
    }   
}