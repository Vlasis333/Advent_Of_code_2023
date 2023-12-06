namespace AdventOfCode2023
{
    public class Day05Puzzle01 : IPuzzle
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay05.txt");

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static long CalculateAnswer(string[] fileData)
        {
            List<long> initialSeeds = GetInitialSeeds(fileData);
            Dictionary<long, long> seedToLocationMapping = GetSeedToLocationMapping(fileData, initialSeeds);
            List<long> lowestLocations = new();

            // Spliting string at this point is the same method, only diffrence is where we split
            foreach (long seed in initialSeeds)
            {
                long location = seedToLocationMapping[seed];
                lowestLocations.Add(location);
            }

            return lowestLocations.Min();
        }

        private static Dictionary<long, long> GetSeedToLocationMapping(string[] fileData, List<long> initialSeeds)
        {
            string concatenatedData = string.Join("\n", fileData);
            string[] parts = concatenatedData.Split("\n\n");

            List<string> locationMappings = parts.Skip(1).ToList();

            List<(long, long, long)[]> mappings = locationMappings
                .Select(s => s.Split('\n').Skip(1)
                    .Select(line => line.Split().Select(long.Parse).ToArray())
                    .Select(arr => (arr[0], arr[1], arr[2]))
                    .ToArray())
                .ToList();

            Dictionary<long, long> resultMapping = new();
            for (int i = 0; i < initialSeeds.Count; i++)
            {
                long currectSeed = initialSeeds[i];
                foreach (var currentMapping in mappings)
                {
                    currectSeed = ApplyMappingsInRange(currectSeed, currentMapping);
                }
                resultMapping.Add(initialSeeds[i], currectSeed);
            }

            return resultMapping;
        }

        private static List<long> GetInitialSeeds(string[] fileData)
        {
            // Used to get the data from the first row of the input
            string concatenatedData = string.Join("\n", fileData);
            string[] parts = concatenatedData.Split("\n\n");

            string seedMappingString = parts[0];
            return seedMappingString.Split(':')[1]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(value => long.Parse(value))
                .ToList();
        }

        private static long ApplyMappingsInRange(long currectSeed, IEnumerable<(long Destination, long Source, long Size)> currentMappingTuples)
        {
            foreach (var mapping in currentMappingTuples)
            {
                if (IsWithinRange(currectSeed, mapping.Source, mapping.Size))
                {
                    currectSeed = ApplyMapping(currectSeed, mapping.Destination, mapping.Source);
                }
            }
            return currectSeed;
        }

        private static bool IsWithinRange(long value, long start, long size)
        {
            // Check if we are within range
            return start <= value && value < start + size;
        }

        private static long ApplyMapping(long originalValue, long destination, long source)
        {
            return originalValue + (destination - source);
        }

    }
}
