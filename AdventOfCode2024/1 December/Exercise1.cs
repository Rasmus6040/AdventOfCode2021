namespace AdventOfCode2024._1_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var puzzleInput = _puzzleInput.Select(x => x.Split("   ").Select(int.Parse).ToList())
            .ToList();

        var firstList = new List<int>();
        var secondList = new List<int>();
        
        foreach (var input in puzzleInput)
        {
            firstList.Add(input[0]);
            secondList.Add(input[1]);
        }
        firstList.Sort();
        secondList.Sort();
        return firstList.Zip(secondList, (x, y) => (x , y)).Aggregate(0, (acc, item) => acc+Math.Abs(item.x - item.y));
    }    
}