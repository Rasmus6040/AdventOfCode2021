namespace AdventOfCode2024._6_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var map = _puzzleInput
            .Select((x, i) => (x, i))
            .SelectMany(x => x.x.Select((y, j) => (x.i, j, y)))
            .ToDictionary(x => (x.i, x.j), x => x.y);
        KeyValuePair<(int,int), char> startPosition = map
            .First(x => x.Value == '^');
        
        var direction = 0;
        var counterLoop = 0;
        var exercise1 = new Exercise1();
        var positionsVisited = exercise1.GetResult();
        Console.WriteLine($"positions to check: {positionsVisited.Count}");
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if (positionsVisited.ContainsKey((i, j)) is false) continue;
                if (startPosition.Key.Item1 == i && startPosition.Key.Item2 == j) continue;
                if (map[(i, j)] != '.') continue;
                
                var originalValue = map[(i, j)];
                map[(i, j)] = '#';
                if (CheckRoute(startPosition.Key, map))
                {
                    map[(i, j)] = '*';
                    counterLoop++;
                }
                else
                {
                    map[(i, j)] = 'M';   
                }
            }
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
        return counterLoop;

        bool CheckRoute((int, int) tempCurrentPosition, Dictionary<(int, int), char> tempMap)
        {
            HashSet<(int i, int j, int direction)> visitedStates = [];
            var tempDirection = direction;
            (int, int) currPos = tempCurrentPosition;
            while (true)
            {
                
                if (!visitedStates.Add((currPos.Item1, currPos.Item2, tempDirection))) return true;
                var (newI, newJ) = NextPosition(tempDirection, currPos);

                if (newJ < 0 || newJ >= _puzzleInput.First().Length) break;
                if (newI < 0 || newI >= _puzzleInput.Length) break;
                if (tempMap[(newI, newJ)] == '#')
                {
                    tempDirection += 1;
                    if(tempDirection == 4) tempDirection = 0;
                    (newI, newJ) = NextPosition(tempDirection, currPos);
                    if (tempMap[(newI, newJ)] == '#')
                    {
                        tempDirection += 1;
                        if(tempDirection == 4) tempDirection = 0;
                        (newI, newJ) = NextPosition(tempDirection, currPos);
                        if (tempMap[(newI, newJ)] == '#')
                        {
                            tempDirection += 1;
                            if(tempDirection == 4) tempDirection = 0;
                            (newI, newJ) = NextPosition(tempDirection, currPos);
                        
                        }   
                    }
                }
                currPos = (newI, newJ);
            }
            return false;
        }
        
        (int, int) NextPosition(int dir, (int i, int j) pos)
        {
            return dir switch
            {
                0 => (pos.i - 1, pos.j), // up
                1 => (pos.i, pos.j + 1), // right
                2 => (pos.i + 1, pos.j), // down
                3 => (pos.i, pos.j - 1), // left
                _ => pos
            };
        }
    }
}