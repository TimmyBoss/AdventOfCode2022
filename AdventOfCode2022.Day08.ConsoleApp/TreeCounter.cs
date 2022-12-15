using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day08.ConsoleApp
{
    public class TreeCounter : ITask
    {
        private TreeGrid _treeGrid = new TreeGrid();

        public string GetAnswer1()
        {
            var amount = _treeGrid.GetAmountOfVisibleTrees();
            return amount.ToString();
        }

        public string GetAnswer2()
        {
            return "";
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            var treeGrid = new TreeGrid();

            foreach (var line in puzzleInput)
            {
                var treeLine = new List<int>();
                foreach (var item in line)
                    treeLine.Add(int.Parse(item.ToString()));

                treeGrid.Add(treeLine);
            }

            _treeGrid = treeGrid;
        }
    }
}
