using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day05.ConsoleApp
{
    internal class SupplyStacker : ITask
    {
        private Stack _stack = new Stack();

        public long GetAnswer1()
        {
            return 0;
        }

        public long GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            var _stack = GetStack(puzzleInput);
        }

        public Stack GetStack(List<string> puzzleInput)
        {
            var stack = new List<string>();
            var i = 0;

            while (!string.IsNullOrEmpty(puzzleInput[i]))
            {
                stack.Add(puzzleInput[i]);
                i++;
            }

            return new Stack(stack);
        }
    }
}
