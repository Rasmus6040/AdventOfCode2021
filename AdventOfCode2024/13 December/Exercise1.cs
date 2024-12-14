using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2024._13_December;

public class Exercise1
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
            var output = inputs[2].Split("=")[1..].Select(x => long.Parse(x.Split(",").First())).ToArray();

            var solutions = new List<(int, int)>();
            for (var a = 0; a < 100; a++)
            {
                for (var b = 0; b < 100; b++)
                {
                    if(buttonA[0]*a+buttonB[0]*b != output[0]) continue;
                    if(buttonA[1]*a+buttonB[1]*b != output[1]) continue;
                    solutions.Add((a,b));
                }
            }
            Console.WriteLine($"Solutions: {solutions.Count}");
            if(solutions.Count == 0) continue;
            var bestSolution = solutions.MinBy(x => x.Item1 * 3 + x.Item2);
            result += bestSolution.Item1*3+bestSolution.Item2;
        }
        return result;
    }
    
    // a(94x+34y)+b(22x+67y)=8400+5400
    

}