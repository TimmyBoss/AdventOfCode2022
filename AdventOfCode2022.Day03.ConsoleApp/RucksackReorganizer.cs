using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day03.ConsoleApp
{
    internal class RucksackReorganizer : ITask
    {
        List<string> _items;

        public long GetAnswer1()
        {
            var totalPriorities = 0;

            foreach (var item in _items)
            {
                totalPriorities += GetPriority(item);
            }

            return totalPriorities;
        }

        public long GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _items = puzzleInput;
        }

        public int GetPriority(string item)
        {
            var firstCompartment = item.Substring(0, (int)(item.Length / 2));
            var lastCompartment = item.Substring((int)(item.Length / 2), (int)(item.Length / 2));
            var priorities = new Priorities();

            foreach (var character in firstCompartment)
            {
                if (lastCompartment.Contains(character))
                    return priorities[character];
            }

            return 0;
        }
    }
}
