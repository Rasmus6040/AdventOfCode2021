namespace AdventOfCode2024._9_December;

public class Exercise2
{
    private readonly string _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        List<(int,int)> longVersion = [];
        int id = 0;
        for (int i = 0; i < _puzzleInput.Length; i++)
        {
            if (i % 2 == 0)
            {
                longVersion.Add((id, int.Parse(_puzzleInput[i].ToString())));
                id++;
            }
            else
            {
                longVersion.Add((-1, int.Parse(_puzzleInput[i].ToString())));
            }
        }

        for (var i = longVersion.Count - 1; i >= 0; i--)
        {
            if (longVersion[i].Item1 == -1) continue;
            var indexChecked = 0;
            while (true)
            {
                var firstDotIndex = longVersion.FindIndex(indexChecked, x => x.Item1 == -1);
                if (firstDotIndex > i) break;
                if (longVersion[firstDotIndex].Item2 == longVersion[i].Item2)
                {
                    (longVersion[firstDotIndex], longVersion[i]) = (longVersion[i], longVersion[firstDotIndex]);
                    break;
                }
                if (longVersion[firstDotIndex].Item2 > longVersion[i].Item2)
                {
                    (int, int) temp = longVersion[firstDotIndex];
                    temp.Item2 -= longVersion[i].Item2;
                    longVersion[firstDotIndex] = temp;
                    
                    (int, int) whatToMove = longVersion[i];
                    longVersion[i] = (-1, whatToMove.Item2);
                    longVersion.Insert(firstDotIndex, whatToMove);
                    break;
                }
                indexChecked++;
            }
        }
        
        // Console.WriteLine(string.Join("",longVersion.SelectMany(x => Enumerable.Repeat(x.Item1 == -1 ? "." : x.Item1.ToString(), x.Item2)).ToList()));
        
        return longVersion
            .SelectMany(x => Enumerable.Repeat(long.Parse(x.Item1.ToString()), x.Item2))
            .Select((x, index) => x == -1 ? 0 : x*index)
            .Sum();
    }
}