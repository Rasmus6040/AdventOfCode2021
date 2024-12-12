using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2024._12_December;

public class Exercise1
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
                        regionsToBeCombined.First().Plots.Add((i, j));
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
        public HashSet<(int, int)> Plots { get; set; } = [];
        public Region((int, int) plot, string type)
        {
            Plots.Add(plot);
            _plotType = type;
        }

        public bool HasNeighborPlot((int i, int j) plot)
        {
            return Plots.Contains((plot.i - 1, plot.j)) ||
                   Plots.Contains((plot.i + 1, plot.j)) ||
                   Plots.Contains((plot.i, plot.j - 1)) ||
                   Plots.Contains((plot.i, plot.j + 1));
        }

        public void AddNewRegions(List<Region> regions)
        {
            foreach ((int, int) regionPlot in regions.SelectMany(region => region.Plots))
            {
                Plots.Add(regionPlot);
            }
        }

        public long FenceCost()
        {
            var totalFenceCost = 0;
            foreach((int i, int j) plot in Plots)
            {
                if(Plots.Contains((plot.i - 1, plot.j)) is false) totalFenceCost++;
                if(Plots.Contains((plot.i + 1, plot.j)) is false) totalFenceCost++;
                if(Plots.Contains((plot.i, plot.j - 1)) is false) totalFenceCost++;
                if(Plots.Contains((plot.i, plot.j + 1)) is false) totalFenceCost++;
            }
            
            Console.WriteLine($"A region of {_plotType} plants with price {Plots.Count} * {totalFenceCost} = {totalFenceCost*Plots.Count}.");
            return totalFenceCost * Plots.Count;
        }
    }

}