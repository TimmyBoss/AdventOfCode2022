using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day06.ConsoleApp
{
    internal class Tuner : ITask
    {
        private string _dataStreamBuffer = "";
        private int sequenceAmount = 0;

        public string GetAnswer1()
        {
            return GetCharacterIndex(4);
        }

        public string GetAnswer2()
        {
            return GetCharacterIndex(14);
        }

        private string GetCharacterIndex(int sequenceAmount)
        {
            var amount = sequenceAmount;

            for (int i = 0; i < _dataStreamBuffer.Length; i++)
            {
                var substring = _dataStreamBuffer.Substring(i, sequenceAmount);
                var hasDuplicates = substring.GroupBy(c => c).Any(g => g.Count() > 1);

                if (!hasDuplicates)
                    break;

                amount++;
            }

            return amount.ToString();
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _dataStreamBuffer = puzzleInput[0];
        }
    }
}
