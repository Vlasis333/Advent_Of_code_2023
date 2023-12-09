namespace AdventOfCode2023
{
    public class Day06Puzzle01 : IPuzzle
    {
        public class BoatRaceData
        {
            public int Time { get; set; }
            public int Distance { get; set; }
        }

        public void Initialize()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay06.txt")));

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
        
        private static int CalculateAnswer(string[] fileData)
        {
            // Main logic
            List<BoatRaceData> boatRaces = PopulateBoatData(fileData);
            int result = 1;

            foreach (var boatRace in boatRaces)
            {
                result *= Enumerable.Range(0, boatRace.Time).Count(record =>
                {
                    int distanceCovered = (boatRace.Time - record) * record;
                    return distanceCovered > boatRace.Distance;
                });
            }

            return result;
        }

        private static List<BoatRaceData> PopulateBoatData(string[] inputArray)
        {
            // Basic to split the data (2 lines) into the entity
            List<BoatRaceData> boatRaces = new();

            string[] timeValues = inputArray[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string[] distanceValues = inputArray[1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < timeValues.Length; i++)
            {
                boatRaces.Add(new BoatRaceData
                {
                    Time = int.Parse(timeValues[i]),
                    Distance = int.Parse(distanceValues[i])
                });
            }

            return boatRaces;
        }
    }
}
