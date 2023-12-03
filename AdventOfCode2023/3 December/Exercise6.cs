namespace AdventOfCode2023._3_December;

public class Exercise6
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();
    private readonly Dictionary<(int,int), int> _position = new ();

    public int GetResult()
    {
        var sum = 0;
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if (!BadWayOfCheckingForSymbol(i, j, out var value)) continue;
                j += value.ToString().Length;
            }
        }

        for(var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                if (_puzzleInput[i][j] != '*') continue;
                var firstNumber = FindFirstNumber(i, j);
                if(firstNumber is null) continue;
                sum += firstNumber.Value;
            }
        }

        return sum;
    }

    private int? FindFirstNumber(int i, int j)
    {
        var foundCount = 0;
        var accumulatedValue = 0;

        // Directions: (deltaI, deltaJ, checkPreviousDeltaI, checkPreviousDeltaJ)
        var directions = new (int, int, int?, int?)[] 
        {
            (-1, -1, null, null), (-1, 0, -1, -1), (-1, 1, -1, 0), 
            (0, -1, null, null), (0, 1, null, null), 
            (1, -1, null, null), (1, 0, 1, -1), (1, 1, 1, 0)
        };

        foreach (var (deltaI, deltaJ, prevDeltaI, prevDeltaJ) in directions)
        {
            if (_position.TryGetValue((i + deltaI, j + deltaJ), out var value))
            {
                // Check if it's the same number as in the previous direction
                var isDifferentNumber = prevDeltaI == null || !_position.TryGetValue((i + prevDeltaI.Value, j + prevDeltaJ!.Value), out _);

                if (isDifferentNumber)
                {
                    foundCount++;
                    accumulatedValue = (accumulatedValue == 0) ? value : accumulatedValue * value;
                }
            }
            
            if (foundCount >= 2 && accumulatedValue != 0) return accumulatedValue;
        }
        return null;
    }

    private bool BadWayOfCheckingForSymbol(int i, int j, out int number)
    {
        var hasSpecialChar = false;
        if (j + 2 < _puzzleInput.First().Length && 
            int.TryParse(_puzzleInput[i].AsSpan(j, 3), out number))
        {
            _position.Add((i,j), number);
            _position.Add((i,j+1), number);
            _position.Add((i,j+2), number);
            hasSpecialChar = true;
        }
        else if (j + 1 < _puzzleInput.First().Length && 
            int.TryParse(_puzzleInput[i].AsSpan(j, 2), out number))
        {
            _position.Add((i,j), number);
            _position.Add((i,j+1), number);
            hasSpecialChar = true;
        }
        else if (j < _puzzleInput.First().Length && 
                 int.TryParse(_puzzleInput[i].AsSpan(j, 1), out number))
        {
            _position.Add((i,j), number);
            hasSpecialChar = true;
        }
        else
        {
            number = 0;
        }
        
        return hasSpecialChar;
    }
}