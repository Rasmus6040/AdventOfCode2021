namespace AdventOfCode2024._5_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var counts = _puzzleInput
            .First()
            .Split("\n")
            .Select(x => (int.Parse(x.Split("|").First()), int.Parse(x.Split("|").Last())))
            .ToList();
        var dict = new Dictionary<int, List<int>>();
        foreach (var count in counts)
        {
            if (dict.TryGetValue(count.Item1, out var list))
            {
                list.Add(count.Item2);
            }
            else
            {
                dict.Add(count.Item1, [count.Item2]);
            }
        }
        
        var updates = _puzzleInput
            .Last()
            .Split("\n")
            .Select(x => 
                x.Split(",")
                    .Select(int.Parse).ToList())
            .ToList();
        var result = 0;
        foreach (var update in updates)
        {
            bool notOrdered = true;
            bool hasBeenOrdered = false;
            while (notOrdered)
            {
                (notOrdered, var i, bool back) = ValidUpdate(update, dict);

                if (notOrdered)
                {
                    hasBeenOrdered = true;
                    if (back)
                    {
                        for (var j = 0; j < i; j++)
                        {
                            if (!dict.TryGetValue(update[i], out var value)) continue;
                            if (!value.Contains(update[j])) continue;
                            (update[i], update[j]) = (update[j], update[i]);
                        }
                    }
                    else
                    {
                        for (var j = i+1; j < update.Count; j++)
                        {
                            if (!dict.TryGetValue(update[i], out var value)) continue;
                            if (value.Contains(update[j])) continue;
                            (update[i], update[j]) = (update[j], update[i]);
                        }    
                    }
                }
                else
                {
                    if(hasBeenOrdered) result += update[(update.Count - 1) / 2];
                }   
            }
        }
        return result;
        
        // First guess: 5109 to high
    }

    private static (bool, int, bool) ValidUpdate(List<int> update, Dictionary<int, List<int>> dict)
    {
        for (var i = 0; i < update.Count; i++)
        {
            for (var j = i+1; j < update.Count; j++)
            {
                if (!dict.TryGetValue(update[i], out var value)) continue;
                if (value.Contains(update[j])) continue;
                return (true, i, false);
            }    
            for (var j = 0; j < i; j++)
            {
                if (!dict.TryGetValue(update[i], out var value)) continue;
                if (!value.Contains(update[j])) continue;
                return (true, i, true);
            }
        }
        return (false, 0, false);
    }
}