using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day04.ConsoleApp
{
    internal class CampCleaner : ITask
    {
        private List<string> _puzzleInput = new List<string>();

        public long GetAnswer1()
        {
            var totalAmount = 0;

            foreach (var item in _puzzleInput)
            {
                var pairs = item.Split(",");
                var firstPair = pairs[0].Split("-").Select(s=> Convert.ToInt32(s)).ToList();
                var secondPair = pairs[1].Split("-").Select(s => Convert.ToInt32(s)).ToList();

                if ((firstPair[0] >= secondPair[0] && firstPair[1] <= secondPair[1]) ||
                    (secondPair[0] >= firstPair[0] && secondPair[1] <= firstPair[1]))
                    totalAmount++;
            }

            return totalAmount;
        }

        public long GetAnswer2()
        {
            var totalAmount = 0;

            foreach (var item in _puzzleInput)
            {
                var pairs = item.Split(",");
                var firstPair = pairs[0].Split("-").Select(s => Convert.ToInt32(s)).ToList();
                var secondPair = pairs[1].Split("-").Select(s => Convert.ToInt32(s)).ToList();

                if ((firstPair[0] >= secondPair[0] && firstPair[0] <= secondPair[1]) ||
                    (firstPair[1] >= secondPair[0] && firstPair[1] <= secondPair[1]) ||
                    (secondPair[0] >= firstPair[0] && secondPair[0] <= firstPair[1]) ||
                    (secondPair[1] >= firstPair[0] && secondPair[1] <= firstPair[1]))
                    totalAmount++;
            }

            return totalAmount;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
    }
}
