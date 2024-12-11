namespace AdventOfCode2024._11_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        int maxDepth = 25;
        Dictionary<long, List<(long, List<long> temp)>> numberToResult = new();
        var startingNumbers = _puzzleInput.First().Split(" ").Select(long.Parse).ToList();

        var result = 0;
        foreach (var startingNumber in startingNumbers)
        {
            result += CreateNewNumbers(startingNumber, 0).Count;
        }
        // Console.WriteLine(string.Join(" ", result));

        // Console.WriteLine(string.Join("\n", numberToResult.Select(x => x.Key + ":  " + string.Join(", ", x.Value.Select(x => x.ToString()))).ToList()));
        
        return result;
        List<long> CreateNewNumbers(long number, long depth)
        {
            if(depth == maxDepth) return [number];
            if (numberToResult.TryGetValue(number, out var result1) && result1.Exists(x => x.Item1+depth < maxDepth))
            {
                var result2 = new List<long>();
                var bestCache = result1.MinBy(x => x.Item1 + depth - maxDepth);
                foreach (var t in bestCache.temp)
                {
                    result2.AddRange(CreateNewNumbers(t, depth+bestCache.Item1));
                }

                return result2;
            }
            List<long> temp;
            if (number == 0)
            {
                temp = CreateNewNumbers(1, depth+1);
                if(numberToResult.ContainsKey(number) && numberToResult[number].Exists(x => x.Item1 == maxDepth-depth) is false) 
                    numberToResult[number].Add((maxDepth-depth, temp));
                else if (numberToResult.ContainsKey(number) is false)
                {
                    numberToResult[number] = [(maxDepth-depth, temp)];
                }
                return temp;
            }

            if (number.ToString().Length % 2 == 0)
            {
                var numberString = number.ToString();
                var splitIndex = numberString.Length / 2;

                var part1String = numberString[..splitIndex];
                var part2String = numberString[splitIndex..];
                var firstPart = CreateNewNumbers(long.Parse(part1String), depth+1);
                var secondPart = CreateNewNumbers(long.Parse(part2String), depth+1);
                temp = [..firstPart, ..secondPart];
                if(numberToResult.ContainsKey(number) && numberToResult[number].Exists(x => x.Item1 == maxDepth-depth) is false) 
                    numberToResult[number].Add((maxDepth-depth, temp));
                else if (numberToResult.ContainsKey(number) is false)
                {
                    numberToResult[number] = [(maxDepth-depth, temp)];
                }
                return temp;
            }
            temp = CreateNewNumbers(number * 2024, depth+1);
            // Console.WriteLine(number + " is added to dictionary");
            if(numberToResult.ContainsKey(number) && numberToResult[number].Exists(x => x.Item1 == maxDepth-depth) is false) 
                numberToResult[number].Add((maxDepth-depth, temp));
            else if (numberToResult.ContainsKey(number) is false)
            {
                numberToResult[number] = [(maxDepth-depth, temp)];
            }
            return temp;
        }
        
    }

}