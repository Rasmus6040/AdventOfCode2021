namespace AdventOfCode2023._10_December;

public class Exercise19
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();
    
    public int GetResult()
    {
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
        };
        
        var rows = _puzzleInput.Length;
        var columns = _puzzleInput.First().Length;
        
        var map = new (bool, int)[rows, columns];
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                map[i, j] = (false, 0);
            }
        }
        
        var queue = new Queue<((int, int), (int, int))>();
        var rowIndex = _puzzleInput.ToList().FindIndex(x => x.Contains('S'));
        var columnIndex = _puzzleInput[rowIndex].IndexOf("S");
        map[rowIndex, columnIndex] = (true, 0);
        
        queue.Enqueue(((1, 0), (rowIndex-1, columnIndex)));
        queue.Enqueue(((-1, 0), (rowIndex+1, columnIndex)));
        // queue.Enqueue(((0, 1), (rowIndex, columnIndex-1)));
        // queue.Enqueue(((0, -1), (rowIndex, columnIndex+1)));
        while (queue.Count != 0)
        {
            var (previousIndices, currentIndices) = queue.Dequeue();
            if(currentIndices.Item1 < 0 || currentIndices.Item1 >= rows ||
               currentIndices.Item2 < 0 || currentIndices.Item2 >= columns) continue;
            var currentPipe = _puzzleInput[currentIndices.Item1][currentIndices.Item2].ToString();
            var next = pipesDict.TryGetValue((previousIndices, currentPipe), out var nextIndices);
            var visited = map[currentIndices.Item1 + nextIndices.Item1, currentIndices.Item2 + nextIndices.Item2];
            if (visited.Item1) return visited.Item2 + 1;
            var previousValue = map[currentIndices.Item1+previousIndices.Item1, currentIndices.Item2+previousIndices.Item2];
            map[currentIndices.Item1, currentIndices.Item2] = (true, previousValue.Item2 + 1);
            
            if(next) queue.Enqueue(((-nextIndices.Item1, -nextIndices.Item2), (currentIndices.Item1+nextIndices.Item1, currentIndices.Item2+nextIndices.Item2)));
            
        }
        
        return 1;
    }
}