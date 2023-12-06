namespace AdventOfCode2023._6_December;

public abstract class PuzzleInput
{
    public static string[] Get()
    {
        const string puzzle = "Time:        48     93     84     66\nDistance:   261   1192   1019   1063";
        return puzzle.Split("\n");
    }
}