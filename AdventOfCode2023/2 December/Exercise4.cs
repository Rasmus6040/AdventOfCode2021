namespace AdventOfCode2023._2_December;

public class Exercise4
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        return _puzzleInput
            .Select(puzzle => puzzle.Split(": "))
            .Select(puzzle => 
                new KeyValuePair<int, CubeBackpack>(
                    int.Parse(puzzle[0].Split(" ")[1]), 
                    CreateCubePack(puzzle[1], new CubeBackpack())))
            .Aggregate(0, (sum, pack) => sum+pack.Value.Blue*pack.Value.Red*pack.Value.Green);
    }

    // Game 2: 10 blue, 12 red; 8 red; 7 green, 5 red, 7 blue
    private static CubeBackpack CreateCubePack(string s, CubeBackpack cubeBackpack)
    {
        var rounds = s.Split("; ")
            .Select(x => x.Split(", "))
            .Select(round => round.Select(input => input.Split(" ")));
            
        rounds.ToList().ForEach(round =>
        {
            round.ToList().ForEach(item =>
            {
                switch (item[1])
                {
                    case "blue":
                        cubeBackpack.Blue = int.Parse(item[0]) > cubeBackpack.Blue ? int.Parse(item[0]) : cubeBackpack.Blue;
                        break;
                    case "red":
                        cubeBackpack.Red = int.Parse(item[0]) > cubeBackpack.Red
                            ? int.Parse(item[0])
                            : cubeBackpack.Red;
                        break;
                    case "green":
                        cubeBackpack.Green = int.Parse(item[0]) > cubeBackpack.Green
                            ? int.Parse(item[0])
                            : cubeBackpack.Green;
                        break;
                }
            });
        });
        return cubeBackpack;
    }
}