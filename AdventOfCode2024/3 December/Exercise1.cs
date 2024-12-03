namespace AdventOfCode2024._3_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var result = 0;
        var muls = string.Join("\n",_puzzleInput).ToLower().Split("mul(")[1..];
        for (var i = 0; i < muls.Length; i++)
        {
            var mul = muls[i].Split(")").First();
            var mulValues = mul.Split(",");
            if (mulValues.Length != 2)
            {
                continue;
            }
            var firstValue = mulValues[0];
            if (firstValue.Length is > 3 or < 1 || (firstValue.All(char.IsDigit) is false))
            {
                continue;
            }

            if (int.TryParse(firstValue, out var firstNumber) is false)
            {
                continue;
            }
            
            var secondValue = mulValues[1];
            if (secondValue.Length is < 1 or > 3 || (secondValue.All(char.IsDigit) is false))
            {
                continue;
            }

            if (int.TryParse(secondValue, out var secondNumber) is false)
            {
                continue;
            }
            result += firstNumber * secondNumber;
        }
        return result;
        // First guess:  38622291
        // Second guess: 30916125: your answer is too low
        // Third guess:  185797128
    }
}