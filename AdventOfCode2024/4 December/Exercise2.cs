namespace AdventOfCode2024._4_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var directions = new (int dx, int dy, int dx2, int dy2)[]
        {
            (1, 1, -1, -1),   // Diagonal right down
            (-1, -1, 1, 1), // Diagonal left up
            (1, -1, -1, 1),  // Diagonal left down
            (-1, 1, 1, -1)   // Diagonal right up
        };

        var counter = 0;

        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput[i].Length; j++)
            {
                foreach (var (dx, dy, dx2, dy2) in directions)
                {
                    if (IsMatch(i, j, dx, dy) && IsMatch(i, j, dx2, dy2))
                        counter++;
                }
            }
        }

        return counter;

        bool IsMatch(int x, int y, int dx, int dy)
        {
            for (int k = -1; k < 2; k++)
            {
                int nx = x + k * dx;
                int ny = y + k * dy;

                if (nx < 0 || ny < 0 || nx >= _puzzleInput.Length || ny >= _puzzleInput[x].Length || _puzzleInput[nx][ny] != "MAS"[k])
                    return false;
            }
            return true;
        }
    }
}