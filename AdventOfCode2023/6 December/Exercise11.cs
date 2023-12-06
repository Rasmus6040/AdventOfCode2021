namespace AdventOfCode2023._6_December;

public class Exercise11
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var races = _puzzleInput.Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToList();
        var result = 1;
        for (var i = 1; i < races.First().Length; i++)
        {
            result *= BoatTravel(int.Parse(races.First()[i]), int.Parse(races.Last()[i]), 0);
        }

        return result;
    }

    private static int BoatTravel(int time, int dist, int currentSpeed)
    {
        if (currentSpeed == time) return 0;
        var record = (time - currentSpeed) * currentSpeed > dist ? 1 : 0;
        return record + BoatTravel(time, dist, currentSpeed + 1);
    }
}