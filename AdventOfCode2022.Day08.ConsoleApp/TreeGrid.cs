
namespace AdventOfCode2022.Day08.ConsoleApp
{
    public class TreeGrid : List<List<int>>
    {


        public TreeGrid()
        { 
        }

        public int GetAmountOfVisibleTrees()
        {
            var amount = 0;

            for (int i = 0; i < Count; i++)
            {
                for (int j=0; j < this[i].Count; j++)
                {
                    if (IsVisibleFromTop(i, j) || IsVisibleFromBottom(i, j) || 
                        IsVisibleFromLeft(i, j) || IsVisibleFromRight(i,j))
                        amount++;              
                }
            }

            return amount;
        }

        public int GetBestScenicScore()
        {
            var bestScenicScore = 0;
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < this[i].Count; j++)
                {
                    var scenicScore = GetCalculatedScenicScore(i, j);

                    if (bestScenicScore < scenicScore)
                        bestScenicScore = scenicScore;
                }
            }

            return bestScenicScore; 
        }

        private int GetCalculatedScenicScore(int rowIndex, int columnIndex)
        {
            var top = GetViewingDistanceFromTop(rowIndex, columnIndex);
            var bottom = GetViewingDistanceFromBottom(rowIndex, columnIndex);
            var left = GetViewingDistanceFromLeft(rowIndex, columnIndex);
            var right = GetViewingDistanceFromRight(rowIndex, columnIndex);

            return top * bottom * left * right; 
        }

        private int GetViewingDistanceFromTop(int rowIndex, int columnIndex)
        {
            var amount = 0;
            var currentAmount = this[rowIndex][columnIndex];

            if (rowIndex > 0)
            {
                for (int i = rowIndex - 1; i >= 0; i--)
                {
                    amount++;
                    var topAmount = this[i][columnIndex];
                    
                    if (currentAmount <= topAmount)
                        break;
                }
            }

            return amount;
        }

        private int GetViewingDistanceFromBottom(int rowIndex, int columnIndex)
        {
            var amount = 0;
            var currentAmount = this[rowIndex][columnIndex];

            if (rowIndex < Count)
            {
                for (int i = rowIndex + 1; i < Count; i++)
                {
                    amount++;
                    var topAmount = this[i][columnIndex];
                    
                    if (currentAmount <= topAmount)
                        break;
                }
            }

            return amount;
        }

        private int GetViewingDistanceFromLeft(int rowIndex, int columnIndex)
        {
            var amount = 0;
            var currentAmount = this[rowIndex][columnIndex];

            if (columnIndex > 0)
            {
                for (int i = columnIndex - 1; i >= 0; i--)
                {
                    amount++;
                    var topAmount = this[rowIndex][i];
                    
                    if (currentAmount <= topAmount)
                        break;
                }
            }

            return amount;
        }

        private int GetViewingDistanceFromRight(int rowIndex, int columnIndex)
        {
            var amount = 0;
            var currentAmount = this[rowIndex][columnIndex];

            if (columnIndex < this[rowIndex].Count)
            {
                for (int i = columnIndex + 1; i < this[rowIndex].Count; i++)
                {
                    amount++;
                    var topAmount = this[rowIndex][i];

                    if (currentAmount <= topAmount)
                        break;
                }
            }

            return amount;
        }

        private bool IsVisibleFromTop(int rowIndex, int columnIndex)
        {
            var isVisible = true;
            var currentAmount = this[rowIndex][columnIndex];

            if (rowIndex > 0)
            {
                for (int i = rowIndex - 1; i >= 0; i--)
                {
                    var topAmount = this[i][columnIndex];
                    isVisible = currentAmount > topAmount;

                    if (!isVisible)
                        break;
                }
            }

            return isVisible;
        }

        private bool IsVisibleFromBottom(int rowIndex, int columnIndex)
        {
            var isVisible = true;
            var currentAmount = this[rowIndex][columnIndex];

            if (rowIndex < Count)
            {
                for (int i = rowIndex + 1; i < Count; i++)
                {
                    var bottomAmount = this[i][columnIndex];
                    isVisible = currentAmount > bottomAmount;

                    if (!isVisible)
                        break;
                }
            }

            return isVisible;
        }

        private bool IsVisibleFromLeft(int rowIndex, int columnIndex)
        {
            var isVisible = true;
            var currentAmount = this[rowIndex][columnIndex];

            if (columnIndex > 0)
            {
                for (int i = columnIndex - 1; i >= 0; i--)
                {
                    var leftAmount = this[rowIndex][i];
                    isVisible = currentAmount > leftAmount;

                    if (!isVisible)
                        break;
                }
            }

            return isVisible;
        }

        private bool IsVisibleFromRight(int rowIndex, int columnIndex)
        {
            var isVisible = true;
            var currentAmount = this[rowIndex][columnIndex];

            if (columnIndex < this[rowIndex].Count)
            {
                for (int i = columnIndex + 1; i < this[rowIndex].Count; i++)
                {
                    var rightAmount = this[rowIndex][i];
                    isVisible = currentAmount > rightAmount;

                    if (!isVisible)
                        break;
                }
            }

            return isVisible;
        }
    }
}
