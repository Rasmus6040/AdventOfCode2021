namespace AdventOfCode._3_December;

public class Exercise5
{
    private readonly string[] _puzzleInput = PuzzleInput3.Get();

    public int GetResultFromExercise5()
    {
        var countOfEachBit = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        _puzzleInput.ToList().ForEach(x =>
        {
            for(var i = 0; i < x.Length; i++)
            {
                countOfEachBit[i] += int.Parse(x[i].ToString());   
            }
        });
        var gamma = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        var epsilon = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        for (var i = 0; i < countOfEachBit.Count; i++)
        {
            gamma[i] = countOfEachBit[i] < _puzzleInput.Length / 2 ? 0 : 1;
            epsilon[i] = countOfEachBit[i] > _puzzleInput.Length / 2 ? 0 : 1;
        }
        var gammaString = string.Join("", gamma);
        var epsilonString = string.Join("", epsilon);
        return Convert.ToInt32(gammaString, 2) * Convert.ToInt32(epsilonString, 2);
    }
}