namespace AdventOfCode2024._11_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        int maxDepth = 75;
        var startingNumbers = _puzzleInput.First().Split(" ").Select(long.Parse).ToList();

        var numbersToLookAtA = startingNumbers.Select(x => (value: x, count: (long)1)).ToList();
        var numbersToLookAtB = startingNumbers.Select(x => (value: x, count: (long)1)).ToList();
        for (var i = 0; i < maxDepth; i++)
        {
            if (i % 2 == 0)
            {
                numbersToLookAtB = [];
                foreach ((long value, long count) number in numbersToLookAtA)
                {
                    var newNumbers = CreateNewNumbers(number.value);
                    var initial = true;
                    var numbersIdentical = false;
                    foreach (var newNumber in newNumbers)
                    {
                        var index = numbersToLookAtB.FindIndex(x => x.value == newNumber);
                        if (index != -1)
                        {
                            var newCount = numbersToLookAtB[index].count + (initial || numbersIdentical is false ? number.count : 1);
                            initial = false;
                            numbersToLookAtB[index] = (newNumber, newCount);
                        }
                        else
                        {
                            numbersToLookAtB.Add((newNumber, number.count));
                        }
                    }
                }
            }
            else
            {
                numbersToLookAtA = [];
                foreach ((long value, long count) number in numbersToLookAtB)
                {
                    var initial = true;
                    var newNumbers = CreateNewNumbers(number.value);
                    var numbersIdentical = false;
                    foreach (var newNumber in newNumbers)
                    {
                        var index = numbersToLookAtA.FindIndex(x => x.value == newNumber);
                        if (index != -1)
                        {
                            var newCount = numbersToLookAtA[index].count + (initial || numbersIdentical is false ? number.count : 1);
                            initial = false;
                            numbersToLookAtA[index] = (newNumber, newCount);
                        }
                        else
                        {
                            numbersToLookAtA.Add((newNumber, number.count));
                        }
                    }
                }
            }
        }
        return numbersToLookAtB.Sum(x => x.count);
        
        List<long> CreateNewNumbers(long number)
        {
            if (number == 0)
            {
                return [1];
            }

            if (number.ToString().Length % 2 == 0)
            {
                var numberString = number.ToString();
                var splitIndex = numberString.Length / 2;

                var part1String = numberString[..splitIndex];
                var part2String = numberString[splitIndex..];
                return [long.Parse(part1String), long.Parse(part2String)];
            }

            return [number * 2024];
        }
    }
}