namespace AdventOfCode2023._3_December;

public abstract class PuzzleInput
{
    public static string[] Get()
    {
        const string puzzle = "467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..";
        return puzzle.Split("\n");
    }
}