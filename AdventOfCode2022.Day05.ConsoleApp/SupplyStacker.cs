using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day05.ConsoleApp
{
    public class SupplyStacker : ITask
    {
        private Stack _stack;

        public string GetAnswer1()
        {
            var answer = "";

            foreach (var item in _stack)
                answer += item.Value.Last();

            return answer;
        }

        public string GetAnswer2()
        {
            var answer = "";

            foreach (var item in _stack)
                answer += item.Value.Last();

            return answer;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            var stack = GetStack(puzzleInput);
            var moveList = puzzleInput.Where(p => p.Contains("move"));

            foreach (var moveString in moveList)
            {
                var move = moveString.Replace("move ", "").Replace("from ", "").Replace("to ", "");
                var moves = move.Split(" ");

                stack.Move(Convert.ToInt32(moves[0]), Convert.ToInt32(moves[1]), Convert.ToInt32(moves[2]));
            }

            _stack = stack;
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
