namespace AdventOfCode2023
{
    public class Day08Puzzle02 : IPuzzle
    {
        // Same class as part 1
        public class Node
        {
            public string Name { get; set; }
            public string[]? Connections { get; set; }
        }

        public class NodeList
        {
            public readonly Dictionary<string, Node> nodes;

            public NodeList()
            {
                nodes = new Dictionary<string, Node>();
            }

            public void AddNode(string name, string[] connections)
            {
                nodes[name] = new Node { Name = name, Connections = connections };
            }

            public string[]? GetNodeConnections(string name)
            {
                return nodes.TryGetValue(name, out Node node) ? node.Connections : Array.Empty<string>();
            }
        }

        public void Initialize()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay08.txt")));

            Console.WriteLine($"Puzzle 02 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static long CalculateAnswer(string[] fileData)
        {
            // Same as part1, only change is the calculations
            NodeList nodeList = new();

            int[] instructions = fileData[0].Select(ParseInstruction).ToArray();
            IEnumerable<string> nodeListArray = fileData.Skip(2);

            foreach (string node in nodeListArray)
            {
                string[] parts = node.Split(new[] { ' ', ',', '(', ')', '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    nodeList.AddNode(parts[0], parts.Skip(1).ToArray());
                }
            }

            return CalculateStepsToEscapeWasteland(nodeList, instructions);
        }

        private static int ParseInstruction(char x)
        {
            // Same as part 1
            return x switch
            {
                'L' => 0,
                _ => 1,
            };
        }

        private static long CalculateStepsToEscapeWasteland(NodeList nodeList, int[] instructions)
        {
            List<(long phase, long period)> ghostFrequencies = new();

            foreach (var node in nodeList.nodes.Values)
            {
                if (node.Name.Length > 2 && node.Name[2] == 'A')
                {
                    var ghostLoopFrequency = FindGhostLoopFrequency(nodeList, instructions, node.Name);
                    ghostFrequencies.Add(ghostLoopFrequency);
                }
            }

            (long steps, _) = FindSynchronicityTuple(ghostFrequencies);

            return steps;
        }

        private static (long steps, long period) FindGhostLoopFrequency(NodeList nodeList, int[] instructions, string? startNode)
        {
            Dictionary<string, long> endSeen = new();

            for (long i = 0; true; i++)
            {
                if (startNode[2] == 'Z')
                {
                    if (endSeen.TryGetValue(startNode, out var lastSeen))
                        return (steps: lastSeen, period: i - lastSeen);
                    else
                        endSeen[startNode] = i;
                }

                startNode = nodeList.GetNodeConnections(startNode)?[instructions[i % instructions.Length]];
            }
        }

        private static (long steps, long period) FindSynchronicityTuple(List<(long steps, long period)> ghostFrequencies)
        {
            (long steps, long period) synchronicityTuple = ghostFrequencies[0];

            for (int i = 1; i < ghostFrequencies.Count; i++)
            {
                var ghostFreq = ghostFrequencies[i];
                synchronicityTuple = AdjustGhostHarmony(synchronicityTuple, ghostFreq);
            }

            return synchronicityTuple;
        }

        private static (long steps, long period) AdjustGhostHarmony((long steps, long period) currentGhostHarmony, (long steps, long period) newGhostFrequency)
        {
            long currentSteps = currentGhostHarmony.steps;
            long currentPeriod = currentGhostHarmony.period;

            while (currentSteps < newGhostFrequency.steps || (currentSteps - newGhostFrequency.steps) % newGhostFrequency.period != 0)
            {
                currentSteps += currentPeriod;
            }

            long nextSample = currentSteps + currentPeriod;

            while ((nextSample - newGhostFrequency.steps) % newGhostFrequency.period != 0)
            {
                nextSample += currentPeriod;
            }

            long updatedPeriod = nextSample - currentSteps;

            return (phase: currentSteps, period: updatedPeriod);
        }
    }
}
