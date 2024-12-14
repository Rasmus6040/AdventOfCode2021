namespace AdventOfCode2024._14_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        long borderX = 101;
        // long borderX = 11;
        long borderY = 103;
        // long borderY = 7;
        long steps = 100;
        //p=0,4 v=3,-3
        var guards = _puzzleInput.Select(line =>
        {
            var split = line.Split(" ");
            var position = split.First().Split("=").Last().Split(",").Select(long.Parse).ToList();
            var velocity = split.Last().Split("=").Last().Split(",").Select(long.Parse).ToList();
            return new Guard((position[0], position[1]), (velocity[0], velocity[1]), (borderX, borderY));
        }).ToList();

        var quadrant = guards.Select(x => x.QuadrantAfterXSteps(steps))
            .Where(x => x != 0)
            .GroupBy(x => x)
            .Select(x => x.Count())
            .ToList();
        // return 0;
        return quadrant.Aggregate(1, (val, acc) => val * acc);
        // To low: 214414200;
        //         233709840
    }

    private class Guard((long, long) initialPos, (long, long) velocity, (long, long) borders)
    {
        private (long, long) Position { get; set; } = initialPos;
        private (long, long) Velocity { get; set; } = velocity;

        public int QuadrantAfterXSteps(long steps)
        {
            var x = (Position.Item1 + Velocity.Item1 * steps) % borders.Item1;
            if(x < 0) x += borders.Item1;
            var y = (Position.Item2 + Velocity.Item2 * steps) % borders.Item2;
            if(y < 0) y += borders.Item2;
            
            if (x < (borders.Item1-1) / 2)
            {
                if (y < (borders.Item2-1) / 2)
                {
                    return 1;
                }
                if ((borders.Item2-1) / 2 < y)
                {
                    return 2;
                }
            }

            else if ((borders.Item1-1) / 2 < x)
            {
                if (y < (borders.Item2-1) / 2)
                {
                    return 3;
                }
                if ((borders.Item2-1) / 2 < y)
                {
                    return 4;
                }
            }
            return 0;
        }
    }
    
}