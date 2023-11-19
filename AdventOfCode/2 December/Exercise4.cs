namespace AdventOfCode._2_December;

public class Exercise4
{
    private readonly string[] _puzzleInput = PuzzleInput2.Get();

    public int GetResultFromExercise4()
    {
        var depth = 0;
        var forward = 0;
        var aim = 0;
        
        _puzzleInput.ToList().ForEach(x =>
        {
            var action = x.Split(" ")[0];
            switch (action)
            {
                case "forward":
                    forward += int.Parse(x.Split(" ")[1]);
                    depth += int.Parse(x.Split(" ")[1])*aim;
                    break;
                case "down":
                    aim += int.Parse(x.Split(" ")[1]);
                    break;
                case "up":
                    aim -= int.Parse(x.Split(" ")[1]);
                    break;
            }
        });
        return depth*forward;
    }
}