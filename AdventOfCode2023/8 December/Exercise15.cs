namespace AdventOfCode2023._8_December;

public class Exercise15
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var instructions = _puzzleInput.First();

        var dict = new Dictionary<string, int>();
        
        _puzzleInput.Skip(2).Select((x, i) => (x, i))
            .ToList().ForEach(tuple => dict.Add(tuple.x.Split(" = ").First(), tuple.i));



        var previous = dict["AAA"];
        var steps = 0;
        while (true)
        {
            foreach (var direct in instructions.Select(direction => 'R' == direction ? 1 : 0))
            {
                var current = _puzzleInput[2 + previous].Split(" = (").Last().Split(")").First().Split(", ")[direct];
                steps++;
                if(current == "ZZZ") return steps;
                previous = dict[current];
            }   
        }
    }    
}