namespace AdventOfCode2024._10_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        List<(int, int)> directions = [(-1, 0), (1, 0), (0, 1), (0, -1)];
        List<(int, int)> startingPositions = [];
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.Length; j++)
            {
                if (_puzzleInput[i][j] == '0')
                {
                    startingPositions.Add((i, j));
                }
            }
        }

        var result = 0;
        foreach (var position in startingPositions)
        {
            var positionsVisited = new HashSet<(int, int)>();
            var stack = new Stack<(int i, int j)>();
            stack.Push((position.Item1, position.Item2));
            while (stack.Count > 0)
            {
                
                var current = stack.Pop();
                if (_puzzleInput[current.i][current.j] == '9')
                {
                    result++;
                }
                foreach (var direction in directions)
                {
                    var next = (current.Item1 + direction.Item1, current.Item2 + direction.Item2);
                    if (next.Item1 >= 0 && next.Item1 < _puzzleInput.Length && next.Item2 >= 0 &&
                        next.Item2 < _puzzleInput.First().Length)
                    {
                        if (int.Parse(_puzzleInput[next.Item1][next.Item2].ToString()) -
                            int.Parse(_puzzleInput[current.i][current.j].ToString()) == 1)
                        {
                            stack.Push((next.Item1, next.Item2));   
                        }
                    }
                }
            }
        }
        
        return result;
    }
}