namespace AdventOfCode2023._3_December;

public class Exercise5
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var sum = 0;
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if (!BadWayOfCheckingForSymbol(i, j, out var value)) continue;
                j += value.ToString().Length;
                sum += value;
            }
        }

        return sum;
    }

    private bool BadWayOfCheckingForSymbol(int i, int j, out int number)
    {
        var hasSpecialChar = false;
        // Check i-1, i, i+1 and for j values: j-1, j, j+1, j+2, j+3
        if (j + 2 < _puzzleInput.First().Length && 
            int.TryParse(_puzzleInput[i].AsSpan(j, 3), out number))
        {
            hasSpecialChar = SpecialCharNearNumber(i, j, 3);
        }
        else if (j + 1 < _puzzleInput.First().Length && 
            int.TryParse(_puzzleInput[i].AsSpan(j, 2), out number))
        {
            hasSpecialChar = SpecialCharNearNumber(i, j, 2);
        }
        else if (j < _puzzleInput.First().Length && 
                 int.TryParse(_puzzleInput[i].AsSpan(j, 1), out number))
        {
            hasSpecialChar = SpecialCharNearNumber(i, j, 1);
        }
        else
        {
            number = 0;
        }
        
        return hasSpecialChar;
    }

    private bool SpecialCharNearNumber(int i, int j, int len)
    {
        var hasSpecialChar = false;
        if (i != 0 && i < _puzzleInput.Length - 1 && j != 0 && j + len < _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j - 1, len+2)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j - 1, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j + len, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i + 1].Substring(j - 1, len + 2)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i == 0 && j != 0 && j + len < _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j - 1, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j + len, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[1].Substring(j - 1, len + 2)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i == _puzzleInput.Length - 1 && j != 0 && j + len < _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j - 1, len + 2)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j - 1, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j + len, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i != 0 && i < _puzzleInput.Length - 1 && j == 0)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(len, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i + 1].Substring(j, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i != 0 && i < _puzzleInput.Length - 1 && j + len == _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j - 1, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j - 1, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i + 1].Substring(j - 1, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i == 0 && j == 0)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(len, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[1].Substring(j, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        
        if (i != 0 && j != 0 && j + len < _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j - 1, len + 2)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i != 0 && j == 0)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i != 0 && j + len == _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j - 1, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (j != 0 && j + len < _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j - 1, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j + len, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (j + len == _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j - 1, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (j == 0)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(len, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        if (i < _puzzleInput.Length - 1 && j != 0 && j + len < _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i + 1].Substring(j - 1, len + 2)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i < _puzzleInput.Length - 1 && j == 0)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i + 1].Substring(j, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i < _puzzleInput.Length - 1 && j + len == _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i + 1].Substring(j - 1, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }
        else if (i == _puzzleInput.Length - 1 && j + len == _puzzleInput.First().Length)
        {
            hasSpecialChar = hasSpecialChar || _puzzleInput[i - 1].Substring(j - 1, len + 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
            hasSpecialChar = hasSpecialChar || _puzzleInput[i].Substring(j - 1, 1)
                .Any(ch => !char.IsLetterOrDigit(ch) && ch != '.');
        }

        return hasSpecialChar;
    }
}