namespace AdventOfCode2024._8_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        var dict = new Dictionary<char, List<(int, int)>>();
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if(_puzzleInput[i][j] == '.') continue;
                if (dict.ContainsKey(_puzzleInput[i][j]))
                {
                    dict[_puzzleInput[i][j]].Add((i, j));
                }
                else
                {
                    dict[_puzzleInput[i][j]] = [(i, j)];
                }
            }
        }

        List<(int, int)> antinodes = [];
        foreach (var signals in dict)
        {
            var antennaPairs = new List<((int, int), (int, int))>();
            for (int i = 0; i < signals.Value.Count; i++)
            {
                for (int j = i + 1; j < signals.Value.Count; j++)
                {
                    antennaPairs.Add((signals.Value[i], signals.Value[j]));
                }
            }

            foreach (((int, int), (int, int)) pair in antennaPairs)
            {
                (int, int) diff = (pair.Item1.Item1 - pair.Item2.Item1, pair.Item1.Item2 - pair.Item2.Item2);
                antinodes.Add((pair.Item1.Item1+diff.Item1, pair.Item1.Item2+diff.Item2));
                antinodes.Add((pair.Item2.Item1-diff.Item1, pair.Item2.Item2-diff.Item2));
            }
        }
        var antenna = antinodes.Where(x => 
            x.Item1 >= 0 && x.Item1 < _puzzleInput.Length && 
            x.Item2 >= 0 && x.Item2 < _puzzleInput.First().Length)
            .GroupBy(x => x.Item1 + ";"+x.Item2).ToList();

        foreach (var a in antenna)
        {
            var line = _puzzleInput[a.First().Item1].ToArray();
            line[a.First().Item2] = '#'; 
            _puzzleInput[a.First().Item1] = new string(line);
        }
        Console.WriteLine(string.Join("\n", _puzzleInput));
        
        return antenna.Count();
    }

}