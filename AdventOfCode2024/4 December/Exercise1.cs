namespace AdventOfCode2024._4_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var counter = 0;
        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput[i].Length; j++)
            {
                // X can be in the Vertical in the direction down
                if (i < _puzzleInput.Length - 3)
                {
                    if(_puzzleInput[i][j] == 'X' && _puzzleInput[i+1][j] == 'M' && _puzzleInput[i+2][j] == 'A' && _puzzleInput[i+3][j] == 'S')
                        counter++;
                    // X can be in the diagonal to the right down
                    if (j < _puzzleInput[i].Length - 3)
                    {
                        if(_puzzleInput[i][j] == 'X' && _puzzleInput[i+1][j+1] == 'M' && _puzzleInput[i+2][j+2] == 'A' && _puzzleInput[i+3][j+3] == 'S')
                            counter++;
                    }

                    // X can be in the diagonal to the left down
                    if (j > 2)
                    {
                        if(_puzzleInput[i][j] == 'X' && _puzzleInput[i+1][j-1] == 'M' && _puzzleInput[i+2][j-2] == 'A' && _puzzleInput[i+3][j-3] == 'S')
                            counter++;
                    }
                }
                
                

                // X can be in the Vertical in the direction up
                if (i > 2)
                {
                    if(_puzzleInput[i][j] == 'X' && _puzzleInput[i-1][j] == 'M' && _puzzleInput[i-2][j] == 'A' && _puzzleInput[i-3][j] == 'S')
                        counter++;
                    // X can be in the diagonal to the right up
                    if (j < _puzzleInput[i].Length - 3)
                    {
                        if(_puzzleInput[i][j] == 'X' && _puzzleInput[i-1][j+1] == 'M' && _puzzleInput[i-2][j+2] == 'A' && _puzzleInput[i-3][j+3] == 'S')
                            counter++;
                    }

                    // X can be in the diagonal to the left up
                    if (j > 2)
                    {
                        if(_puzzleInput[i][j] == 'X' && _puzzleInput[i-1][j-1] == 'M' && _puzzleInput[i-2][j-2] == 'A' && _puzzleInput[i-3][j-3] == 'S')
                            counter++;
                    }
                }
                
                // X can be in the horizontal to the right
                if (j < _puzzleInput[i].Length - 3)
                {
                    if(_puzzleInput[i][j] == 'X' && _puzzleInput[i][j+1] == 'M' && _puzzleInput[i][j+2] == 'A' && _puzzleInput[i][j+3] == 'S')
                        counter++;
                }

                // X can be in the horizontal to the left
                if (j > 2)
                {
                    if(_puzzleInput[i][j] == 'X' && _puzzleInput[i][j-1] == 'M' && _puzzleInput[i][j-2] == 'A' && _puzzleInput[i][j-3] == 'S')
                        counter++;
                }
            }
        }
        return counter;
    }
}