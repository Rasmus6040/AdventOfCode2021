namespace AdventOfCode2024._17_December;

public class PuzzleInput
{
    public static string[] Get()
    {
        const string puzzle = "Register A: 53437164\nRegister B: 0\nRegister C: 0\n\nProgram: 2,4,1,7,7,5,4,1,1,4,5,5,0,3,3,0";
        // const string puzzle = "Register A: 729\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1,5,4,3,0";
        return puzzle.Split("\n");
    }
}