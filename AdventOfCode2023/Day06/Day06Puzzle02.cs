namespace AdventOfCode2023
{
    public class Day06Puzzle02 : IPuzzle
    {
        // Same as part 1, but distance is now long
        public class BoatRaceData
        {
            public int Time { get; set; }
            public long Distance { get; set; }
        }

        public void Calculation()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay06.txt")));

            Console.WriteLine($"Puzzle 02 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static long CalculateAnswer(string[] fileData)
        {
            // Very similar to part 1 but we have 1 race (and working with long)
            BoatRaceData boatRace = PopulateBoatData(fileData);

            return Enumerable.Range(0, (int)Math.Min(int.MaxValue, boatRace.Time)).Count(record =>
            {
                long distanceCovered = ((long)boatRace.Time - record) * record;
                return distanceCovered > boatRace.Distance;
            });
        }

        private static BoatRaceData PopulateBoatData(string[] inputArray)
        {
            // Same as part 1, but not we have only 1 race
            string[] timeValues = inputArray[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string[] distanceValues = inputArray[1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int raceTime = int.Parse(string.Concat(timeValues[1], timeValues[2], timeValues[3], timeValues[4]));
            long raceDistance = long.Parse(string.Concat(distanceValues[1], distanceValues[2], distanceValues[3], distanceValues[4]));

            return new BoatRaceData
            {
                Time = raceTime,
                Distance = raceDistance
            };
        }
    }
}