namespace AdventOfCode2024._4_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var counter = 0;
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput[i].Length; j++)
            {
                if (_puzzleInput[i][j] == 'A' && i < _puzzleInput.Length - 1 && i > 0 && j < _puzzleInput[i].Length - 1 && j > 0)
                {
                    if (_puzzleInput[i - 1][j - 1] == 'M' && _puzzleInput[i + 1][j + 1] == 'S')
                    {
                        if (_puzzleInput[i + 1][j - 1] == 'M' && _puzzleInput[i - 1][j + 1] == 'S')
                        {
                            counter++;
                        }   
                        if (_puzzleInput[i + 1][j - 1] == 'S' && _puzzleInput[i - 1][j + 1] == 'M')
                        {
                            counter++;
                        }   
                    }
                    if (_puzzleInput[i - 1][j - 1] == 'S' && _puzzleInput[i + 1][j + 1] == 'M')
                    {
                        if (_puzzleInput[i + 1][j - 1] == 'M' && _puzzleInput[i - 1][j + 1] == 'S')
                        {
                            counter++;
                        }   
                        if (_puzzleInput[i + 1][j - 1] == 'S' && _puzzleInput[i - 1][j + 1] == 'M')
                        {
                            counter++;
                        }   
                    }
                }
            }
        }
        return counter;
        
        // First answer: 103 To low
    }
}