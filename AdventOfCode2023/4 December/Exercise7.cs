using System.Globalization;

namespace AdventOfCode2023._4_December;

public class Exercise7
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        return int.Parse(
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
                    tuple.Item2.Aggregate(1, (sum, current) => tuple.Item1.Exists(x => x == current) ? sum * 2 : sum))
                .Sum(tuple => decimal.Floor(tuple/2)).ToString(CultureInfo.InvariantCulture));
    }    
}