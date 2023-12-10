using System.Text;

namespace AdventOfCode2023._10_December;

public class Exercise20
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var newPuzzleInput = _puzzleInput.Select(line => new[]
            { string.Join("", line.Select(x => x + "0")), string.Join("", line.Select(x => "00")) }).SelectMany(x => x).ToArray();;
        var pipesDict = new Dictionary<((int, int), string), (int, int)>
        {
            { ((1, 0), "|"), (-1, 0) },
            { ((-1, 0), "|"), (1, 0) },
            { ((0, 1), "-"), (0, -1) },
            { ((0, -1), "-"), (0, 1) },
            { ((-1, 0), "L"), (0, 1) },
            { ((0, 1), "L"), (-1, 0) },
            { ((-1, 0), "J"), (0, -1) },
            { ((0, -1), "J"), (-1, 0) },
            { ((1, 0), "7"), (0, -1) },
            { ((0, -1), "7"), (1, 0) },
            { ((1, 0), "F"), (0, 1) },
            { ((0, 1), "F"), (1, 0) },
            { ((1, 0), "0"), (-1, 0) },
            { ((-1, 0), "0"), (1, 0) },
            { ((0, 1), "0"), (0, -1) },
            { ((0, -1), "0"), (0, 1) }
        };

        var rows = newPuzzleInput.Length;
        var columns = newPuzzleInput.First().Length;

        var map = new (bool, int)[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                map[i, j] = (false, 0);
            }
        }

        var queue = new Queue<((int, int), (int, int))>();
        var rowIndex = newPuzzleInput.ToList().FindIndex(x => x.Contains('S'));
        var columnIndex = newPuzzleInput[rowIndex].IndexOf("S");
        map[rowIndex, columnIndex] = (true, 0);

        queue.Enqueue(((1, 0), (rowIndex - 1, columnIndex)));
        queue.Enqueue(((-1, 0), (rowIndex + 1, columnIndex)));
        while (queue.Count != 0)
        {
            var (previousIndices, currentIndices) = queue.Dequeue();
            if (currentIndices.Item1 < 0 || currentIndices.Item1 >= rows ||
                currentIndices.Item2 < 0 || currentIndices.Item2 >= columns) continue;
            var currentPipe = newPuzzleInput[currentIndices.Item1][currentIndices.Item2].ToString();
            var next = pipesDict.TryGetValue((previousIndices, currentPipe), out var nextIndices);
            var visited = map[currentIndices.Item1 + nextIndices.Item1, currentIndices.Item2 + nextIndices.Item2];
            if (visited.Item1)
            {
                map[currentIndices.Item1, currentIndices.Item2] = (true, 1);
                break;
            }
            var previousValue = map[currentIndices.Item1 + previousIndices.Item1,
                currentIndices.Item2 + previousIndices.Item2];
            map[currentIndices.Item1, currentIndices.Item2] = (true, previousValue.Item2 + 1);

            if (next)
                queue.Enqueue(((-nextIndices.Item1, -nextIndices.Item2),
                    (currentIndices.Item1 + nextIndices.Item1, currentIndices.Item2 + nextIndices.Item2)));
        }
        PrintMap(map, newPuzzleInput);

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                if (i != 0 || i != rows - 1)
                {
                    if (j == 0 || j == columns - 1) DfsFromEdgeToFindAllNotInclosedInLoop(map, i, j);
                }
                else
                {
                    DfsFromEdgeToFindAllNotInclosedInLoop(map, i, j);
                } 
            }
        }
        
        var count = 0;
        for (var i = 0; i < rows; i+=2)
        {
            for (var j = 0; j < columns; j+=2)
            {
                if (!map[i, j].Item1) count++;
            }
        }
        
        return count;
    }

    private void PrintMap((bool, int)[,] map, string[] newPuzzleInput)
    {
        var rows = map.GetLength(0);
        var columns = map.GetLength(1);
        for (var i = 0; i < rows; i+=2)
        {
            var sb = new StringBuilder();
            for (var j = 0; j < columns; j+=2)
            {
                sb.Append(map[i, j].Item1 ? newPuzzleInput[i][j] : "X");
            }
            Console.WriteLine(sb.ToString());
        }
    }

    private void DfsFromEdgeToFindAllNotInclosedInLoop((bool, int)[,] map, int startI, int startJ)
    {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((startI, startJ));
        while (queue.Count != 0)
        {
            var (i, j) = queue.Dequeue();
            if (i > 0 && !map[i-1, j].Item1)
            {
                queue.Enqueue((i-1, j));
                map[i-1, j] = (true, 0);
            }
            if (i < map.GetLength(0)-1 && !map[i+1, j].Item1)
            {
                queue.Enqueue((i+1, j));
                map[i+1, j] = (true, 0);
            }
            if (j > 0 && !map[i, j-1].Item1)
            {
                queue.Enqueue((i, j-1));
                map[i, j-1] = (true, 0);
            }

            if (j >= map.GetLength(1)-1 || map[i, j + 1].Item1) continue;
            queue.Enqueue((i, j+1));
            map[i, j+1] = (true, 0);
        }
    }
}