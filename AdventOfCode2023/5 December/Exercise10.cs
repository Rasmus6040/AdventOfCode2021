namespace AdventOfCode2023._5_December;

public class Exercise10
{
     private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        var seeds = _puzzleInput
            .First()
            .Split(": ")
            .Last()
            .Split(" ")
            .Select(long.Parse)
            .Select((value, index) => new { value, index })
            .GroupBy(x => x.index / 2)
            .Select(group => (group.First().value, group.Last().value))
            .ToList();
        
        
        var seedToSoilRules = new List<(long, long, long)>();
        var soilToFertilizerRules = new List<(long, long, long)>();
        var fertilizerToWaterRules = new List<(long, long, long)>();
        var waterToLightRules = new List<(long, long, long)>();
        var lightToTemperatureRules = new List<(long, long, long)>();
        var temperatureToHumidityRules = new List<(long, long, long)>();
        var humidityToLocationRules = new List<(long, long, long)>();

        var entry = 0;
        var currentRules = seedToSoilRules;
        
        
        _puzzleInput.Skip(2).ToList().ForEach(line =>
        {
            if (line == "")
            {
                entry++;
                SelectNewRule();
                return;
            }

            if (line.Contains(':')) return;
            
            var split = line.Split(" ");
            var destination = long.Parse(split[0]);
            var source = long.Parse(split[1]);
            var range = long.Parse(split[2]);
            
            currentRules.Add((source, destination, range));
        });

        for (long i = 0; i < 10000000000; i++)
        {
            var humidityObject = humidityToLocationRules.Find(rule => rule.Item2 <= i  && i < rule.Item2 + rule.Item3);
            var humidityValue = humidityObject is { Item2: 0, Item3: 0 } ? i : i + (humidityObject.Item1 - humidityObject.Item2); 
            
            var temperatureObject = temperatureToHumidityRules.Find(rule => rule.Item2 <= humidityValue && humidityValue < rule.Item2 + rule.Item3);
            var temperatureValue = temperatureObject is { Item1: 0, Item3: 0 } ? humidityValue : humidityValue + (temperatureObject.Item1 - temperatureObject.Item2);
            
            var lightObject = lightToTemperatureRules.Find(rule => rule.Item2 <= temperatureValue && temperatureValue < rule.Item2 + rule.Item3);
            var lightValue = lightObject is { Item1: 0, Item3: 0 } ? temperatureValue : temperatureValue + (lightObject.Item1 - lightObject.Item2);
            
            var waterObject = waterToLightRules.Find(rule => rule.Item2 <= lightValue && lightValue < rule.Item2 + rule.Item3);
            var waterValue = waterObject is { Item1: 0, Item3: 0 } ? lightValue : lightValue + (waterObject.Item1 - waterObject.Item2);
            
            var fertilizerObject = fertilizerToWaterRules.Find(rule => rule.Item2 <= waterValue && waterValue < rule.Item2 + rule.Item3);
            var fertilizerValue = fertilizerObject is { Item1: 0, Item3: 0 } ? waterValue : waterValue + (fertilizerObject.Item1 - fertilizerObject.Item2);
            
            var soilObject = soilToFertilizerRules.Find(rule => rule.Item2 <= fertilizerValue && fertilizerValue < rule.Item2 + rule.Item3);
            var soilValue = soilObject is { Item1: 0, Item3: 0 } ? fertilizerValue : fertilizerValue + (soilObject.Item1 - soilObject.Item2);
            
            var seedObject = seedToSoilRules.Find(rule => rule.Item2 <= soilValue && soilValue < rule.Item2 + rule.Item3);
            var seedValue = seedObject is { Item1: 0, Item3: 0 } ? soilValue : soilValue + (seedObject.Item1 - seedObject.Item2);
            if(i % 100000 == 0) Console.WriteLine(i + " " + seedValue);
            
            var result = seeds.Find(x => x.Item1 <= seedValue && seedValue < x.Item1+x.Item2);
            if (result is not {Item1: 0, Item2: 0}) return i;
        }

        return 0;
        
        void SelectNewRule()
        {
            currentRules = entry switch
            {
                0 => seedToSoilRules,
                1 => soilToFertilizerRules,
                2 => fertilizerToWaterRules,
                3 => waterToLightRules,
                4 => lightToTemperatureRules,
                5 => temperatureToHumidityRules,
                6 => humidityToLocationRules,
                _ => currentRules
            };
        }
    }
}