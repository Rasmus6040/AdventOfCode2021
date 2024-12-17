
using System.Text;

namespace AdventOfCode2024._16_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        // N = 0;
        // E = 1;
        // S = 2;
        // W = 3;
        var startPos = ((List<(int, int)>)[], 0, 0, 0, 0);
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if (_puzzleInput[i][j] == 'S')
                {
                    startPos = ([], i, j, 1, 0);
                }
            }
        }
        
        PriorityQueue<(List<(int, int)> history, int x, int y, int dir, int score), int> priorityQueue = new();
        priorityQueue.Enqueue(startPos, 0);
        Dictionary<(int, int), int> visitedCells = new();
        var final = new List<(int, int)>();
        var result = 0;
        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Dequeue();
            if (result != 0 && current.score > result) break;
            (int, int) vector = GetDirectionVector(current.dir);
            if(visitedCells.TryGetValue((current.x, current.y), out var oldScore) && oldScore + 2000 < current.score) continue;
            if(visitedCells.TryGetValue((current.x, current.y), out _) is false) visitedCells[(current.x, current.y)] = current.score;
            
            var newScore = current.score + 1;
            var newX = current.x + vector.Item1;
            var newY = current.y + vector.Item2;
            var newDir = current.dir;
            UpdateQueue(newX, newY, newScore, current, newDir);
            
            // Turn right
            newDir = current.dir+1 == 4 ? 0 : current.dir+1;
            vector = GetDirectionVector(newDir);
            newScore = current.score + 1+1000;
            newX = current.x + vector.Item1;
            newY = current.y + vector.Item2;
            UpdateQueue(newX, newY, newScore, current, newDir);
               
            // Turn Left
            newDir = current.dir - 1 == -1 ? 3 : current.dir - 1;
            vector = GetDirectionVector(newDir);
            newScore = current.score + 1+1000;
            newX = current.x + vector.Item1;
            newY = current.y + vector.Item2;
            UpdateQueue(newX, newY, newScore, current, newDir);
            
        }

        var stringBuilder = new StringBuilder();
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if(final.Contains((i, j))) stringBuilder.Append("O");
                else stringBuilder.Append(_puzzleInput[i][j]);
            }
            stringBuilder.AppendLine();
        }
        Console.WriteLine(stringBuilder.ToString());
        
        return final.Distinct().Count()+1;
        // 492 to low, but somehow someone's else puzzle answer?

        void UpdateQueue(int newX, int newY, int newScore, (List<(int, int)> history, int x, int y, int dir, int score) current, int newDir)
        {
            if (_puzzleInput[newX][newY] == '.')
            {
                priorityQueue.Enqueue(([..current.history, (newX, newY)], newX, newY, newDir, newScore), newScore);
            }
            else if (_puzzleInput[newX][newY] == 'E')
            {
                if (result == 0 || result == newScore)
                {
                    final.AddRange([..current.history, (newX, newY)]);
                    result = newScore;
                }
                else if (result > newScore)
                {
                    final = [..current.history, (newX, newY)];
                    result = newScore;
                }
            }
        }
    }

    private (int, int) GetDirectionVector(int currentDir)
        => currentDir switch
        {
            0 => (-1, 0),
            1 => (0, 1),
            2 => (1, 0),
            3 => (0, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(currentDir), currentDir, null)
        };
}