namespace AdventOfCode2024._13_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        //Button A: X+94, Y+34
        // Button B: X+22, Y+67
        // Prize: X=8400, Y=5400
        var result = (long)0;
        foreach (var machine in _puzzleInput)
        {
            var inputs = machine.Split("\n");
            var buttonA = inputs[0].Split("+")[1..].Select(x => long.Parse(x.Split(",").First())).ToArray();
            var buttonB = inputs[1].Split("+")[1..].Select(x => long.Parse(x.Split(",").First())).ToArray();
            var output = inputs[2].Split("=")[1..].Select(x => long.Parse(x.Split(",").First())).Select(x => x+10000000000000).ToArray();

            var solutions = new List<(long, long)>();
            double determinant = buttonA[0] * buttonB[1] - buttonA[1] * buttonB[0];
            if (determinant == 0)
            {
                Console.WriteLine($"Solution 1: {solutions.Count}");
                continue;
            }
            double a = (output[0] * buttonB[1] - output[1] * buttonB[0]) / determinant;
            double b = (buttonA[0] * output[1] - buttonA[1] * output[0]) / determinant;
            Console.WriteLine($"a: {a}, b: {b}");
            if(Math.Abs((long)a - a) < double.Epsilon*2 && Math.Abs((long)b - b) < 
               double.Epsilon*2) solutions.Add(((long)a,(long)b));

            Console.WriteLine($"Solutions: {solutions.Count}");
            if(solutions.Count == 0) continue;
            var bestSolution = solutions.MinBy(x => x.Item1 * 3 + x.Item2);
            result += bestSolution.Item1*3+bestSolution.Item2;
        }
        return result;
    }

    // a(94x+34y)+b(22x+67y)=8400+5400
    // a(94x+34y)=8400x+5400y-b(22x+67y)
    // a=(8400x+5400y-b(22x+67y))/(94x+34y)
    
}
