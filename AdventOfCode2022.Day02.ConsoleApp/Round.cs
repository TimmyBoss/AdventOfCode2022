namespace AdventOfCode2022.Day02.ConsoleApp
{
    public class Round
    {
        public Round(string opponentMove, string myMove)
        {
            OpponentMove = opponentMove;
            MyMove = myMove;
        }

        public string OpponentMove { get; private set; }
        public string MyMove { get; private set; }
    }
}
