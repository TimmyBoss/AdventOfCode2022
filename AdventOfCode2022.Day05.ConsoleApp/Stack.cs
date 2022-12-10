/*
[C] [B] [H]
[W]     [D] [J] [Q] [B]
[P] [F] [Z] [F] [B] [L]
[G] [Z] [N] [P] [J] [S] [V]
[Z] [C] [H] [Z] [G] [T] [Z]     [C]
[V] [B] [M] [M] [C] [Q] [C] [G] [H]
[S] [V] [L] [D] [F] [F] [G] [L] [F]
[B] [J] [V] [L] [V] [G] [L] [N] [J]
1   2   3   4   5   6   7   8   9 
*/

namespace AdventOfCode2022.Day05.ConsoleApp
{
    public class Stack : Dictionary<int, string>
    {
        public Stack() { }

        public Stack(List<string> stackList)
        {

            var stackIds = stackList.Last().Replace(" ", "");

            foreach (var stackId in stackIds)
            {
                Add(Convert.ToInt32(stackId.ToString()), "");
            }

            for (int i = stackList.Count - 2; i >= 0; i--)
            {
                var cleanString = stackList[i].Chunk(4).ToList();

                for (int j = 0; j < stackIds.Length; j++)
                    this[j + 1] += cleanString[j][1];
            }

            for (int j = 0; j < stackIds.Length; j++)
                this[j + 1] = this[j+1].Replace(" ", "");
        }

        public void Move(int amount, int from, int to)
        {
            var items = this[from].Substring(this[from].Length - amount, amount);
            this[from] = this[from].Remove(this[from].Length - amount);
            this[to] = this[to] += items;
        }
    }
}
