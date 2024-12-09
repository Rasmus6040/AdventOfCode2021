namespace AdventOfCode2024._6_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public Dictionary<(int, int), int> GetResult()
    {
        var map = _puzzleInput
            .Select((x, i) => (x, i))
            .SelectMany(x => x.x.Select((y, j) => (x.i, j, y)))
            .ToDictionary(x => (x.i, x.j), x => x.y);
        KeyValuePair<(int,int), char> currentPosition = map
            .First(x => x.Value == '^');
        
        var positionsVisited = new Dictionary<(int, int), int>();
        var direction = 0;
        while (true)
        {
            if (positionsVisited.ContainsKey((currentPosition.Key.Item1, currentPosition.Key.Item2)))
                positionsVisited[(currentPosition.Key.Item1, currentPosition.Key.Item2)] += 1;
            else positionsVisited.Add((currentPosition.Key.Item1, currentPosition.Key.Item2), 1);
            map[currentPosition.Key] = 'X';
            int newJ = 0;
            int newI = 0;
            
            switch (direction)
            {
                case 0:
                    newI = currentPosition.Key.Item1-1;
                    newJ = currentPosition.Key.Item2;
                    break;
                case 1:
                    newI = currentPosition.Key.Item1;
                    newJ = currentPosition.Key.Item2+1;
                    break;
                case 2:
                    newI = currentPosition.Key.Item1+1;
                    newJ = currentPosition.Key.Item2;
                    break;
                case 3:
                    newI = currentPosition.Key.Item1;
                    newJ = currentPosition.Key.Item2-1;
                    break;
            }

            if (newJ < 0 || newJ >= _puzzleInput.First().Length) break;
            if (newI < 0 || newI >= _puzzleInput.Length) break;
            if (map[(newI, newJ)] == '#')
            {
                direction += 1;
                if(direction == 4) direction = 0;
                switch (direction)
                {
                    case 0:
                        newI = currentPosition.Key.Item1-1;
                        newJ = currentPosition.Key.Item2;
                        break;
                    case 1:
                        newI = currentPosition.Key.Item1;
                        newJ = currentPosition.Key.Item2+1;
                        break;
                    case 2:
                        newI = currentPosition.Key.Item1+1;
                        newJ = currentPosition.Key.Item2;
                        break;
                    case 3:
                        newI = currentPosition.Key.Item1;
                        newJ = currentPosition.Key.Item2-1;
                        break;
                }
            }
            currentPosition = map.First(x => x.Key == (newI, newJ));
        }

        var mapPrint = new List<(int, char)>();
        foreach (var entry in map.ToList())
        {
            mapPrint.Add((entry.Key.i*_puzzleInput.First().Length+entry.Key.j, entry.Value));
        }
        var test = mapPrint.OrderBy(x => x.Item1)
            .Chunk(_puzzleInput.First().Length)
            .Select(x => new string(x.Select(y => y.Item2).ToArray()))
            .ToList();
        Console.WriteLine(string.Join("\n",test));
        
        return positionsVisited;
        
        // First guess 141 to low.
    }
}