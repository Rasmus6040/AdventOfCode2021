using System.Text.Json;

namespace AdventOfCode2024._9_December;

public class Exercise1
{
    private readonly string _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        List<int> longVersion = [];
        int id = 0;
        for (int i = 0; i < _puzzleInput.Length; i++)
        {
            if (i % 2 == 0)
            {
                longVersion.AddRange(Enumerable.Repeat(id, int.Parse(_puzzleInput[i].ToString())).ToList());
                id++;
            }
            else
            {
                longVersion.AddRange(Enumerable.Repeat(-1, int.Parse(_puzzleInput[i].ToString())).ToList());
            }
        }

        for (var i = longVersion.Count - 1; i >= 0; i--)
        {
            if (longVersion[i] == -1) continue;
            var firstDotIndex = longVersion.IndexOf(-1);
            if (firstDotIndex > i) break;
            (longVersion[firstDotIndex], longVersion[i]) = (longVersion[i], longVersion[firstDotIndex]);
        }
        return longVersion.Where(x => x != -1).Select((x, index) => long.Parse(x.ToString())*index).Sum();
    }

}