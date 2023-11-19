namespace AdventOfCode._1_December;

public class Exercise1
{
    private readonly int[] _puzzleInput = PuzzleInput.Get();

    public int GetResultFromExercise1()
    {
        return _puzzleInput.Where((x, index) => index != 0 && x > _puzzleInput[index - 1]).Count();
    }
}

