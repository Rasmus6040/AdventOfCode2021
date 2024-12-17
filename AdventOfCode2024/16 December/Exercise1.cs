using System.Text;
using System.Xml;

namespace AdventOfCode2024._16_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        // N = 0;
        // E = 1;
        // S = 2;
        // W = 3;
        var startPos = (0, 0, 0, 0);
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if (_puzzleInput[i][j] == 'S')
                {
                    startPos = (i, j, 1, 0);
                }
            }
        }

        var result = -1;
        PriorityQueue<(int x, int y, int dir, int score), int> priorityQueue = new();
        priorityQueue.Enqueue(startPos, 0);
        Dictionary<(int, int), int> visitedCells = new();
        
        while (priorityQueue.Count > 0)
        {
            (int x, int y, int dir, int score) current = priorityQueue.Dequeue();
            Console.WriteLine(current.x + " -- " + current.y + " -- " + current.score);
            if (visitedCells.TryGetValue((current.x, current.y), out var score))
            {
                if (score < current.score) continue;
                
            }
            if(result != -1 && result < current.score) return result;
            (int, int) vector = GetDirectionVector(current.dir);
            if (_puzzleInput[current.x + vector.Item1][current.y + vector.Item2] == '.'  && (visitedCells.TryGetValue((current.x + vector.Item1, current.y + vector.Item2), out var score1) is false || score1 > current.score + 1))
            {
                priorityQueue.Enqueue((current.x + vector.Item1, current.y + vector.Item2, current.dir, current.score + 1), current.score+1);
                visitedCells[(current.x + vector.Item1, current.y + vector.Item2)] = current.score + 1;
            }
            else if (_puzzleInput[current.x + vector.Item1][current.y + vector.Item2] == 'E')
            {
                result = current.score < result || result == -1 ? current.score+1 : result;
            }
            // Turn right
            vector = GetDirectionVector(current.dir+1 == 4 ? 0 : current.dir+1);
            if (_puzzleInput[current.x + vector.Item1][current.y + vector.Item2] == '.' && (visitedCells.TryGetValue((current.x + vector.Item1, current.y + vector.Item2), out var score2) is false || score2 > current.score + 1 + 1000))
            {
                priorityQueue.Enqueue((current.x + vector.Item1, current.y + vector.Item2, current.dir+1 == 4 ? 0 : current.dir+1, current.score + 1+1000), current.score+1+1000);
                visitedCells[(current.x + vector.Item1, current.y + vector.Item2)] = current.score + 1 + 1000;
            }
            else if (_puzzleInput[current.x + vector.Item1][current.y + vector.Item2] == 'E')
            {
                result = current.score < result || result == -1 ? current.score+1+1000 : result;
            }   
            // Turn Left
            vector = GetDirectionVector(current.dir-1 == -1 ? 3 : current.dir-1);
            if (_puzzleInput[current.x + vector.Item1][current.y + vector.Item2] == '.'  && (visitedCells.TryGetValue((current.x + vector.Item1, current.y + vector.Item2), out var score3) is false || score3 > current.score + 1 + 1000))
            {
                priorityQueue.Enqueue((current.x + vector.Item1, current.y + vector.Item2, current.dir-1 == -1 ? 3 : current.dir-1, current.score + 1+1000), current.score+1+1000);
                visitedCells[(current.x + vector.Item1, current.y + vector.Item2)] = current.score + 1 + 1000;
            }
            else if (_puzzleInput[current.x + vector.Item1][current.y + vector.Item2] == 'E')
            {
                result = current.score < result || result == -1 ? current.score+1+1000 : result;
            }   
            
        }
        return result;
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
