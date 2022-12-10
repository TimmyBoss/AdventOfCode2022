using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day01.ConsoleApp
{
    public class CalorieCounter : ITask
    {
        private List<int> _totalCaloriesList = new List<int>();

        public string GetAnswer1()
        {
            var maxTotalCalories = _totalCaloriesList.Max();
            return maxTotalCalories.ToString();
        }

        public string GetAnswer2()
        {
            var sorted = _totalCaloriesList.OrderByDescending(t => t).Take(3);
            return sorted.Sum().ToString();
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
