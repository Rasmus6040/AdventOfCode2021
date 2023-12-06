namespace AdventOfCode2023._6_December;

public class Exercise12
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        var races = _puzzleInput.Select(x => x.Replace(" ", "").Split(":", StringSplitOptions.RemoveEmptyEntries)).ToList();
        var result = BoatTravel(long.Parse(races.First()[1]), long.Parse(races.Last()[1]), 0, 0);

        return result.Item2-result.Item1;
    }

    private static (long, long) BoatTravel(long time, long dist, long currentSpeed, long first)
    {
        while (true)
        {
            if (currentSpeed == time) break;
            var record = (time - currentSpeed) * currentSpeed > dist ? 1 : 0;
            if (record == 0 && first != 0) break;
            if (record != 0)
            {
                var currentSpeed1 = currentSpeed;
                currentSpeed += 1;
                if(first == 0) first = currentSpeed1;
                continue;
            }

            currentSpeed += 1;
            first = 0;
        }

        return (first, currentSpeed);
    }
}