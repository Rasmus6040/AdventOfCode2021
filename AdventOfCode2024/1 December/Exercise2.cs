namespace AdventOfCode2024._1_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var input1Dict = new Dictionary<int, int>();
        var input2Dict = new Dictionary<int, int>();

        foreach (var line in _puzzleInput)
        {
            var tokens = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            int input1 = int.Parse(tokens[0]);
            int input2 = int.Parse(tokens[1]);

            if (!input1Dict.TryAdd(input1, 1))
                input1Dict[input1]++;

            if (!input2Dict.TryAdd(input2, 1))
                input2Dict[input2]++;
        }

        int result = 0;
        foreach (var key in input1Dict.Keys)
        {
            if (input2Dict.TryGetValue(key, out var countIn2))
            {
                result += key * input1Dict[key] * countIn2;
            }
        }

        return result;
    }    
}