using System.Text;

namespace AdventOfCode2024._15_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public async Task<long> GetResult()
    {
        //"########\n#..O.O.#\n##@.O..#\n#...O..#\n#.#.O..#\n#...O..#\n#......#\n########\n\n<^^>>>vv<v>>v<<";
        var map = new Map(_puzzleInput.First());
        map.PrintMap();
        var counter = 0;
        foreach (var move in _puzzleInput.Last())
        {
            counter++;
            if (move == '\n') continue;
            // await Task.Delay(200);
            Console.WriteLine("Move "+move +": and counter" + counter);
            map.Move(move);
            if(counter == 6977) map.PrintMap();
        }
        var sum = map.PrintMap();
        return sum;
        
        // First guess: 1581581 to high
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
            _width = (mapLatitudes[0].Length-2)*2;
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width/2; j++)
                {
                    switch (mapLatitudes[i][j+1])
                    {
                        case '#':
                            Walls.Add((i, j*2));
                            Walls.Add((i, j*2+1));
                            break;
                        case 'O':
                            Boxes.Add((i, j*2));
                            break;
                        case '@':
                            Robot = (i, j*2);
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

            var stack = new Stack<(long, long)>();
            stack.Push((Robot.Item1+vect.Item1, Robot.Item2+vect.Item2));
            var firstStep = true;
            var boxes = new List<(long, long)>();
            while (stack.Count > 0)
            {
                var pos = stack.Pop();
                
                if (Walls.Contains(pos) || 
                    (firstStep is false && Walls.Contains((pos.Item1, pos.Item2+1)))) return;
                
                if (pos.Item1 >= _height || pos.Item2 >= _width ||
                    pos.Item1 < 0 || pos.Item2 < 0 || (firstStep is false && pos.Item2 == _width-1)) return;

                if ((vect == (1, 0) || vect == (-1, 0)) && firstStep is false)
                {
                    if (Boxes.Contains((pos.Item1, pos.Item2 - 1)) && Boxes.Contains((pos.Item1, pos.Item2 + 1)))
                    {
                        boxes.Add((pos.Item1, pos.Item2 - 1));
                        stack.Push((pos.Item1 + vect.Item1, pos.Item2-1));
                        boxes.Add((pos.Item1, pos.Item2 + 1));
                        stack.Push((pos.Item1 + vect.Item1, pos.Item2 + 1));
                        continue;
                    }
                    if (Boxes.Contains((pos.Item1, pos.Item2 - 1)))
                    {
                        boxes.Add((pos.Item1, pos.Item2 - 1));
                        stack.Push((pos.Item1 + vect.Item1, pos.Item2-1));
                        continue;
                    }
                    if (Boxes.Contains((pos.Item1, pos.Item2 + 1)))
                    {
                        boxes.Add((pos.Item1, pos.Item2 + 1));
                        stack.Push((pos.Item1 + vect.Item1, pos.Item2 + 1));
                        continue;
                    }
                }
                if (Boxes.Contains((pos.Item1, pos.Item2)))
                {
                    boxes.Add(pos);
                    stack.Push((pos.Item1 + vect.Item1, pos.Item2 + vect.Item2));
                    firstStep = false;
                    continue;
                }
                if (Boxes.Contains((pos.Item1, pos.Item2-1)) && vect != (0, 1))
                {
                    boxes.Add((pos.Item1, pos.Item2 - 1));
                    stack.Push((pos.Item1 + vect.Item1, pos.Item2-1 + vect.Item2));
                    firstStep = false;
                    continue;
                }

                if (Boxes.Contains((pos.Item1, pos.Item2 + 1)) && vect == (0, 1) && firstStep is false)
                {
                    boxes.Add((pos.Item1, pos.Item2 + 1));
                    stack.Push((pos.Item1 + vect.Item1, pos.Item2+1 + vect.Item2));
                    firstStep = false;
                }
            }
            
            foreach ((long, long) box in boxes)
            {
                Boxes.Remove(box);
            }

            foreach ((long, long) box in boxes.Distinct())
            {
                Boxes.Add((box.Item1+vect.Item1, box.Item2+vect.Item2));
            }

            if (Boxes.GroupBy(x => x).Any(x => x.Count() > 1))
            {
                var collisions = Boxes.GroupBy(x => x).ToList();
                PrintMap();
                throw new Exception();
            }

            Robot = (Robot.Item1 + vect.Item1, Robot.Item2 + vect.Item2);
        }

        public int PrintMap()
        {
            var sum = 0;
            var builder = new StringBuilder();
            for (var i = 0; i < _height+2; i++)
            {
                for (var j = 0; j < _width+4; j++)
                {
                    if (i < 1 || i > _height || j < 2 || j > _width + 1)
                    {
                        builder.Append('#');
                        continue;
                    }

                    if (Robot.Item1 == i-1 && Robot.Item2 == j - 2)
                    {
                        builder.Append('@');
                        continue;
                    }

                    if (Boxes.Contains((i - 1, j - 2)))
                    {
                        builder.Append('[');
                        builder.Append(']');
                        sum += 100 * i + j;
                        // Console.WriteLine(i + " i, " + j + " j, " + (100 * i + j));
                        j++;
                        continue;
                    }
                    if (Walls.Contains((i - 1, j - 2)))
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