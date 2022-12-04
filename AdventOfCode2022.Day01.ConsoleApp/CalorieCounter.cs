using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day01.ConsoleApp
{
    public class CalorieCounter : ITask
    {
        private List<int> _totalCaloriesList = new List<int>();

        public long GetAnswer1()
        {
            var maxTotalCalories = _totalCaloriesList.Max();
            return maxTotalCalories;
        }

        public long GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            var totalCalories = 0;

            foreach (var calorie in puzzleInput)
            {
                if (!string.IsNullOrEmpty(calorie))
                    totalCalories += Convert.ToInt32(calorie);
                else
                {
                    _totalCaloriesList.Add(totalCalories);
                    totalCalories = 0;
                }
            }
        }
    }
}
