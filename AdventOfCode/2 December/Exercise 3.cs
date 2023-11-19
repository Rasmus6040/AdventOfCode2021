namespace AdventOfCode._2_December;

public class Exercise3
{
    private readonly string[] _puzzleInput = PuzzleInput2.Get();

    public int GetResultFromExercise3()
    {
        var forward = 0;
        var down = 0;
        var up = 0;
        
        _puzzleInput.ToList().ForEach(x =>
        {
            var action = x.Split(" ")[0];
            switch (action)
            {
                case "forward":
                    forward += int.Parse(x.Split(" ")[1]);
                    break;
                case "down":
                    down += int.Parse(x.Split(" ")[1]);
                    break;
                case "up":
                    up += int.Parse(x.Split(" ")[1]);
                    break;
            }
        });
        return forward * (down - up);
    }
}

