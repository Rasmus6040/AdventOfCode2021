using System.Text;
using System.Xml;

namespace AdventOfCode2024._15_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        //"########\n#..O.O.#\n##@.O..#\n#...O..#\n#.#.O..#\n#...O..#\n#......#\n########\n\n<^^>>>vv<v>>v<<";
        var map = new Map(_puzzleInput.First());
        map.PrintMap();
        foreach (var move in _puzzleInput.Last())
        {
            map.Move(move);
            Console.WriteLine("Move "+move +":");
            // map.PrintMap();
        }
        var sum = map.PrintMap();
        return sum;
    }
    private class Map
    {
        private HashSet<(long, long)> Walls {get; set;} = [];
        private List<(long, long)> Boxes { get; set; } = [];
        private (long, long) Robot {get; set;}
        private readonly long _width;
        private readonly long _height;
        public Map(string stringMap)
        {
            var mapLatitudes = stringMap.Split("\n")[1..^1];
            _height = mapLatitudes.Length;
            _width = mapLatitudes[0].Length-2;
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    switch (mapLatitudes[i][j+1])
                    {
                        case '#':
                            Walls.Add((i, j));
                            break;
                        case 'O':
                            Boxes.Add((i, j));
                            break;
                        case '@':
                            Robot = (i, j);
                            break;
                    }
                }
            }
        }

        public void Move(char direction)
        {
            // ^^>>>vv<v>>v<
            var vect = (0, 0);
            switch (direction)
            {
                case '<':
                    vect = (0, -1);
                    break;
                case '>':
                    vect = (0, 1);
                    break;
                case 'v':
                    vect = (1, 0);
                    break;
                case '^':
                    vect = (-1, 0);
                    break;
                default:
                    return;
            }
            MoveBoxes(vect);
        }

        private void MoveBoxes((int, int) vect)
        {
            if (Robot.Item1 + vect.Item1 >= _height || Robot.Item2 + vect.Item2 >= _width ||
                Robot.Item1 + vect.Item1 < 0 || Robot.Item2 + vect.Item2 < 0) return;
            
            (long, long) pos = (Robot.Item1+vect.Item1, Robot.Item2+vect.Item2);
            var boxes = new List<(long, long)>();
            while (true)
            {
                if (Walls.Contains(pos)) return;
                if (pos.Item1 >= _height || pos.Item2 >= _width ||
                    pos.Item1 < 0 || pos.Item2 < 0) return;
                if (Boxes.Contains(pos))
                {
                    boxes.Add(pos);
                    pos = (pos.Item1 + vect.Item1, pos.Item2 + vect.Item2);
                    continue;
                }
                break;
            }
            
            foreach ((long, long) box in boxes)
            {
                Boxes.Remove(box);
            }

            foreach ((long, long) box in boxes)
            {
                Boxes.Add((box.Item1+vect.Item1, box.Item2+vect.Item2));
            }

            Robot = (Robot.Item1 + vect.Item1, Robot.Item2 + vect.Item2);
        }

        public int PrintMap()
        {
            var sum = 0;
            var builder = new StringBuilder();
            for (var i = 0; i < _height+2; i++)
            {
                for (var j = 0; j < _width+2; j++)
                {
                    if (i == 0 || i == _height+1 || j == 0 || j == _width + 1)
                    {
                        builder.Append('#');
                        continue;
                    }

                    if (Robot.Item1 == i-1 && Robot.Item2 == j - 1)
                    {
                        builder.Append('@');
                        continue;
                    }

                    if (Boxes.Contains((i - 1, j - 1)))
                    {
                        builder.Append('O');
                        sum += 100 * i + j;
                        continue;
                    }
                    if (Walls.Contains((i - 1, j - 1)))
                    {
                        builder.Append('#');
                        continue;
                    }
                    builder.Append(' ');
                    
                }
                builder.AppendLine();
            }
            Console.WriteLine(builder.ToString());
            return sum;
        }
    }
}
