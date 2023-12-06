namespace AdventOfCode2023
{
    public class Day05Puzzle02 : IPuzzle
    {
        class SeedPath
        {
            public long Start { get; }
            public long End { get; }
            public long Offset { get; }

            public SeedPath(long start, long end, long offset)
            {
                Start = start;
                End = end;
                Offset = offset;
            }
        }

        class Seed
        {
            public long Start { get; }
            public long End { get; }

            public Seed(long start, long end)
            {
                Start = start;
                End = end;
            }
        }

        public void Calculation()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay05.txt")));

            Console.WriteLine($"Puzzle 02 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static long CalculateAnswer(string[] fileData)
        {
            List<long> initialSeeds = GetInitialSeeds(fileData);
            var seedsPaths = GetStartEndOfSeedsMap(initialSeeds);

            List<List<SeedPath>> totalDataPaths = GetFileData(fileData);

            long min = long.MaxValue;

            foreach (Seed seedPath in seedsPaths)
            {
                long start = seedPath.Start;
                long end = seedPath.End;

                min = FindMin(totalDataPaths, min, start, end);
            }

            return min;
        }

        private static long FindMin(List<List<SeedPath>> totalDataPaths, long min, long start, long end)
        {
            // Main logic
            // Disclaimer: I could not find a better solution than to just loop everything searching for the min value
            for (long i = start; i <= end; i++)
            {
                long currentStart = i;
                long skipCount = long.MaxValue;

                foreach (List<SeedPath> dataPaths in totalDataPaths)
                {
                    foreach (SeedPath path in dataPaths)
                    {
                        if (currentStart >= path.Start && currentStart <= path.End)
                        {
                            // Updating skipCount and then moving to the next
                            skipCount = Math.Min(path.End - currentStart, skipCount);
                            currentStart += path.Offset;

                            break;
                        }
                    }
                }

                if (currentStart > min && skipCount != long.MaxValue && skipCount > 0)
                    i += skipCount;

                min = Math.Min(min, currentStart);
            }

            return min;
        }

        private static List<List<SeedPath>> GetFileData(string[] fileData)
        {
            var maps = new List<List<SeedPath>>();
            bool category = false;

            foreach (string line in fileData[1..])
            {
                if (line == "")
                {
                    category = true;
                }
                else if (category)
                {
                    category = false;
                    maps.Add(new List<SeedPath>());
                }
                else
                {
                    maps.Last().Add(GetRangeLine(line));
                }
            }

            return maps;
        }

        private static SeedPath GetRangeLine(string line)
        {
            var parts = line.Split(' ');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);
            long offSet = long.Parse(parts[2]);
            return new SeedPath(end, end + offSet - 1, start - end);
        }

        private static List<long> GetInitialSeeds(string[] fileData)
        {
            // Same as Part 1
            string concatenatedData = string.Join("\n", fileData);
            string[] parts = concatenatedData.Split("\n\n");

            string seedMappingString = parts[0];
            return seedMappingString.Split(':')[1]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(value => long.Parse(value))
                .ToList();
        }

        private static Seed[] GetStartEndOfSeedsMap(List<long> initialSeeds)
        {
            // Just to get the range for each 
            List<Seed> seedsList = new();

            for (int i = 0; i < initialSeeds.Count; i += 2)
            {
                long start = initialSeeds[i];
                long end = start + initialSeeds[i + 1] - 1;
                seedsList.Add(new Seed(start, end));
            }

            return seedsList.ToArray();
        }
    }
}