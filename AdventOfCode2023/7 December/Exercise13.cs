namespace AdventOfCode2023._7_December;

public class Exercise13
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    /* Guesses
     * 252344859 
     * 251691757
     * 251927063
     */
    
    public int GetResult()
    {
        return _puzzleInput.Select(cardAndBet => cardAndBet.Split(" "))
            .Select(cardAndBet => (cardAndBet.First(), cardAndBet.Last(), GetStrengthOfHand(cardAndBet.First())))
            .GroupBy(cardWithBetAndStrength => cardWithBetAndStrength.Item3)
            .OrderBy(group => group.Key)
            .Select(OrderGroupByStrength)
            .SelectMany(group => group.Select(x => int.Parse(x.Item2)))
            .Select((value, index) => (index+1)*value)
            .Sum();
    }

    private IGrouping<int, (string, string, int)> OrderGroupByStrength(IGrouping<int, (string, string, int)> group)
    {
        return group.OrderBy(x => ConvertHand(x.Item1)).GroupBy(x => x.Item3).First();
    }

    private string ConvertHand(string hand)
    {
        return hand.Replace("A", "E")
            .Replace("K", "D")
            .Replace("Q", "C")
            .Replace("J", "B")
            .Replace("T", "A");
    }
    
    /*
     * Five of a kind: AAAAA (Length 1) 7
     * 
       Four of a kind: AA8AA (Length 2) 6
       Full house: 23332 (Length 2) 5 
       
       Three of a kind: TTT98 (Length 3) 4 (2, 4, 4) 8TTT9 -> TTT9 -> 89 | 8TTT
       Two pair: 23432 (Length 3) 3 (3, 3, 4) 42332 -> 2332 -> 433 | 422
       
       One pair: A23A4 (Length 4) 2
       High card: 23456 (Length 5) 1
       A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, or 2
     */
    private static int GetStrengthOfHand(string hand)
    {
        return int.Parse(string.Join("", hand.Select(ch => hand.Count(ch2 => ch2 == ch))
            .OrderByDescending(ch => ch)
            .Select(ch => ch.ToString())));
    }
}