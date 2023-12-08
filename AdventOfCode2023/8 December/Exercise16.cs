namespace AdventOfCode2023._8_December;

public class Exercise16
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        var instructions = _puzzleInput.First().Select(direction => 'R' == direction ? 1 : 0).ToList();

        var dict = new Dictionary<string, int>();
        
        _puzzleInput.Skip(2).Select((x, i) => (x, i))
            .ToList().ForEach(tuple => dict.Add(tuple.x.Split(" = ").First(), tuple.i));
        
        var previous = _puzzleInput.Skip(2).Where(x => x.Split(" = ").First().Last() == 'A').Select(x => dict[x.Split(" = ").First()]).ToList();

        var counts = new List<int>();
        for (var i = 0; i < previous.Count; i++)
        {
            var foundResult = false;
            var localCount = 0;
            while (!foundResult)
            {
                foreach (var current in instructions.Select(t => _puzzleInput[2 + previous[i]].Split(" = (").Last().Split(")").First().Split(", ")[t]))
                {
                    previous[i] = dict[current];
                    localCount++;
                    if (!current.EndsWith("Z")) continue;
                    
                    counts.Add(localCount);
                    foundResult = true;
                    break;
                }
            }
        }
        return GetLcm(counts.ToArray());
    }       
    
    // Function to find the LCM of an array of numbers
    private static long GetLcm(IReadOnlyList<int> numbers)
    {
        long result = numbers[0];
        for (var i = 1; i < numbers.Count; i++)
        {
            result = GetLcm(result, numbers[i]);
        }
        return result;
    }

    // Function to find LCM of two numbers
    private static long GetLcm(long a, long b)
    {
        return a * b / GetGcd(a, b);
    }

    // Function to find GCD of two numbers
    private static long GetGcd(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}