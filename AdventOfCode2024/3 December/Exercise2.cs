namespace AdventOfCode2024._3_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var donts = string.Join("\n",_puzzleInput).ToLower().Split("don't()");
        var result = GetResultOfDoSection(donts.First());   
        for (var j = 1; j < donts.Length; j++)
        {
            var doesItWork = donts[j].Split("do()");
            if(doesItWork.Length < 2) continue;
            result += doesItWork[1..].Sum(GetResultOfDoSection);
        }
        return result;
        // First guess: 89798695
    }

    private int GetResultOfDoSection(string doSection)
    {
        var muls = doSection.ToLower().Split("mul(")[1..];
        var result = 0;
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
    }
}