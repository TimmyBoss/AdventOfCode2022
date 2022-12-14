
namespace AdventOfCode2022.Day08.ConsoleApp
{
    public class TreeGrid : List<List<int>>
    {
        public int GetTop(int rowIndex, int columnIndex)
        {
            return this[rowIndex-1][columnIndex];
        }

        public int GetBottom(int rowIndex, int columnIndex)
        {
            return this[rowIndex + 1][columnIndex];
        }

        public int GetLeft(int rowIndex, int columnIndex)
        {
            return this[rowIndex - 1][columnIndex];
        }

        public int GetRight(int rowIndex, int columnIndex)
        {
            return this[rowIndex + 1][columnIndex];
        }
    }
}
