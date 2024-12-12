namespace AdventOfCode2024._12_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        Dictionary<char, List<Region>> regions = new();

        for (var i = 0; i < _puzzleInput.Length; i++)
        {
            for (var j = 0; j < _puzzleInput.First().Length; j++)
            {
                var plotType = _puzzleInput[i][j];
                if (regions.TryGetValue(plotType, out var localRegions))
                {
                    var regionsToBeCombined = localRegions
                        .Where(localRegion => localRegion.HasNeighborPlot((i, j))).ToList();
                    if (regionsToBeCombined.Any())
                    {
                        if (regionsToBeCombined.Count > 1)
                        {
                            regionsToBeCombined.First().AddNewRegions(regionsToBeCombined[1..]);
                            regions[plotType] = localRegions
                                .Where(x => regionsToBeCombined[1..].Exists(y => y.Id == x.Id) is false).ToList();
                        }
                        regionsToBeCombined.First().Plots.Add((i,j), new Plot((i, j)));
                    }
                    else
                    {
                        localRegions.Add(new Region((i,j), plotType.ToString()));
                    }
                }
                else
                {
                    regions.Add(plotType, [new Region((i, j), plotType.ToString())]);
                }
            }
        }

        return regions.SelectMany(regionType => regionType.Value).Sum(region => region.FenceCost());
    }

    private class Region
    {
        public Guid Id = Guid.NewGuid();
        private string _plotType;
        public Dictionary<(int, int), Plot> Plots { get; set; } = [];
        public Region((int, int) plot, string type)
        {
            Plots.Add(plot, new Plot(plot));
            _plotType = type;
        }

        public bool HasNeighborPlot((int i, int j) plot)
        {
            return Plots.ContainsKey((plot.i - 1, plot.j)) ||
                   Plots.ContainsKey((plot.i + 1, plot.j)) ||
                   Plots.ContainsKey((plot.i, plot.j - 1)) ||
                   Plots.ContainsKey((plot.i, plot.j + 1));
        }

        public void AddNewRegions(List<Region> regions)
        {
            foreach (var regionPlot in regions.SelectMany(region => region.Plots))
            {
                Plots.Add(regionPlot.Key, regionPlot.Value);
            }
        }

        public long FenceCost()
        {
            var totalFenceCost = 0;
            List<Plot> plots = Plots.Values.ToList();
            
            foreach(Plot plot in plots)
            {
                if (Plots.ContainsKey((plot.Position.Item1 - 1, plot.Position.Item2)) is false)
                {
                    plot.North = true;
                    if (Plots.TryGetValue((plot.Position.Item1, plot.Position.Item2 - 1), out Plot? leftPlot) &
                        Plots.TryGetValue((plot.Position.Item1, plot.Position.Item2 + 1), out Plot? rightPlot))
                    {
                        if (leftPlot!.North is false && rightPlot!.North is false)
                        {
                            totalFenceCost++;
                        }
                    }
                    else if (leftPlot is not null)
                    {
                        if (leftPlot.North is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else if(rightPlot is not null)
                    {
                        if (rightPlot.North is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else
                    {
                        totalFenceCost++;
                    }
                }

                if (Plots.ContainsKey((plot.Position.Item1 + 1, plot.Position.Item2)) is false)
                {
                    plot.South = true;
                    if (Plots.TryGetValue((plot.Position.Item1, plot.Position.Item2 - 1), out Plot? leftPlot) &
                        Plots.TryGetValue((plot.Position.Item1, plot.Position.Item2 + 1), out Plot? rightPlot))
                    {
                        if (leftPlot!.South is false && rightPlot!.South is false)
                        {
                            totalFenceCost++;
                        }
                    }
                    else if (leftPlot is not null)
                    {
                        if (leftPlot.South is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else if(rightPlot is not null)
                    {
                        if (rightPlot.South is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else
                    {
                        totalFenceCost++;
                    }
                }

                if (Plots.ContainsKey((plot.Position.Item1, plot.Position.Item2 - 1)) is false)
                {
                    plot.West = true;
                    if (Plots.TryGetValue((plot.Position.Item1-1, plot.Position.Item2), out Plot? upPlot) &
                        Plots.TryGetValue((plot.Position.Item1+1, plot.Position.Item2), out Plot? downPlot))
                    {
                        if (upPlot!.West is false && downPlot!.West is false)
                        {
                            totalFenceCost++;
                        }
                    }
                    else if (upPlot is not null)
                    {
                        if (upPlot.West is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else if(downPlot is not null)
                    {
                        if (downPlot.West is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else
                    {
                        totalFenceCost++;
                    }
                }

                if (Plots.ContainsKey((plot.Position.Item1, plot.Position.Item2 + 1)) is false)
                {
                    plot.East = true;
                    if (Plots.TryGetValue((plot.Position.Item1-1, plot.Position.Item2), out Plot? upPlot) &
                        Plots.TryGetValue((plot.Position.Item1+1, plot.Position.Item2), out Plot? downPlot))
                    {
                        if (upPlot!.East is false && downPlot!.East is false)
                        {
                            totalFenceCost++;
                        }
                    }
                    else if (upPlot is not null)
                    {
                        if (upPlot.East is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else if(downPlot is not null)
                    {
                        if (downPlot.East is false )
                        {
                            totalFenceCost++;
                        }
                    }
                    else
                    {
                        totalFenceCost++;
                    }
                }
            }
            
            Console.WriteLine($"A region of {_plotType} plants with price {Plots.Count} * {totalFenceCost} = {totalFenceCost*Plots.Count}.");
            return totalFenceCost * Plots.Count;
        }
    }
    
    private class Plot((int i, int j) position)
    {
        public (int, int) Position { get; set; } = position;
        public bool North { get; set; }
        public bool South { get; set; }
        public bool East { get; set; }
        public bool West { get; set; }
    }

}
