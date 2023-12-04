namespace AdventOfCode2023._4_December;

public class Exercise8
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var listOfWon =
            _puzzleInput.Select(card =>
                    card.Split(": ")
                        .Last()
                        .Split(" | "))
                .Select(card =>
                (
                    card.First().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(number => int.Parse(number)).ToList(),
                    card.Last().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(number => int.Parse(number)).ToList()
                ))
                .Select(tuple =>
                    tuple.Item2.Aggregate(0, (sum, current) => tuple.Item1.Exists(x => x == current) ? sum + 1 : sum)).ToList();

        var dict = new Dictionary<int, int>();
        for (var i = 0; i < listOfWon.Count; i++)
        {
            dict[i] = 1;
        }

        for(var i = 0; i < listOfWon.Count; i++)
        {
            for(var j = 0; j < listOfWon[i]; j++)
            {
                GetNewDict(dict, i, j);
            }
        }

        return dict.Sum(x => x.Value);
    }

    private void GetNewDict(Dictionary<int, int> localDict, int current, int offSet)
    {
        var currentEntry = localDict.GetValueOrDefault(current, 0);
        localDict[current+offSet+1] += currentEntry;
    }
}