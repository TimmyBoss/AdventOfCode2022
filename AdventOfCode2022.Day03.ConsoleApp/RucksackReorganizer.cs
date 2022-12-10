using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day03.ConsoleApp
{
    internal class RucksackReorganizer : ITask
    {
        List<string> _items = new List<string>();
        List<List<string>> _itemGroups = new List<List<string>>();

        public string GetAnswer1()
        {
            var totalPriorities = 0;

            foreach (var item in _items)
            {
                totalPriorities += GetPriority(item);
            }

            return totalPriorities.ToString();
        }

        public string GetAnswer2()
        {
            var totalPriorities = 0;
            var priorities = new Priorities();

            foreach (var itemGroup in _itemGroups)
            {
                var recurringChar = GetRecurringCharInGroup(itemGroup);
                totalPriorities += priorities[recurringChar];
            }
            return totalPriorities.ToString();
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _items = puzzleInput;
            _itemGroups = GetItemGroups(puzzleInput);
        }

        public List<List<string>> GetItemGroups(List<string> puzzleInput)
        {
            var itemGroups = new List<List<string>>();

            int i = 0;
            int chunkSize = 3;
            itemGroups = puzzleInput.GroupBy(s => i++ / chunkSize).Select(g => g.ToList()).ToList();
            return itemGroups;
        }

        public int GetPriority(string item)
        {
            var firstCompartment = item.Substring(0, item.Length / 2);
            var lastCompartment = item.Substring(item.Length / 2, item.Length / 2);
            var priorities = new Priorities();

            foreach (var character in firstCompartment)
            {
                if (lastCompartment.Contains(character))
                    return priorities[character];
            }

            return 0;
        }

        public char GetRecurringCharInGroup(List<string> itemGroup)
        {
            var item = itemGroup[0];

            foreach (var character in item)
            {
                if (itemGroup[1].Contains(character) && itemGroup[2].Contains(character))
                    return character;
            }

            return '\0';
        }

    }
}
