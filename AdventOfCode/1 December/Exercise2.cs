namespace AdventOfCode._1_December;

public class Exercise2
{
    private readonly int[] _puzzleInput = PuzzleInput.Get();

    public int GetResultFromExercise2()
    {
        var puzzleAccumulated = _puzzleInput.Select((x, i) => i < _puzzleInput.Length - 2 ? x + _puzzleInput[i + 1] + _puzzleInput[i + 2] : 0).ToArray()[..^2];
        return puzzleAccumulated.Where((x, index) => index != 0 && x > puzzleAccumulated[index - 1]).Count();
    }
}