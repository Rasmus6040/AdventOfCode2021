namespace AdventOfCode2024._2_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public int GetResult()
    {
        var puzzleInput = _puzzleInput.Select(x => x.Split(" ").Select(int.Parse).ToList())
            .ToList();
        
        var unsafeList = puzzleInput.Where(x => 
            x.Aggregate(x.First()-1, (last, next) => last == -1 ? -1 : (last < next && next-last < 4) ? next : -1) == -1 && 
            x.Aggregate(x.First()+1, (last, next) => last == int.MaxValue ? int.MaxValue : (last > next && last-next < 4) ? next : int.MaxValue) == int.MaxValue);


        var finalList = new List<List<int>>();
        foreach (var report in unsafeList)
        {
            bool unsafeReport = true;
            for (int i = 0; i < report.Count; i++)
            {
                var modifiedReport = report.Where((_, index) => index != i).ToList();
                var stillUnsafe = modifiedReport.Aggregate(modifiedReport.First() - 1,
                                      (last, next) => last == -1 ? -1 : (last < next && next - last < 4) ? next : -1) ==
                                  -1 &&
                                  modifiedReport.Aggregate(modifiedReport.First() + 1,
                                      (last, next) =>
                                          last == int.MaxValue ? int.MaxValue :
                                          (last > next && last - next < 4) ? next : int.MaxValue) == int.MaxValue;
                if (stillUnsafe is false)
                {
                    unsafeReport = false;
                    break;
                }
            }

            if (unsafeReport)
            {
                finalList.Add(report);
            }
        }
        return puzzleInput.Count - finalList.Count;
    }   
}