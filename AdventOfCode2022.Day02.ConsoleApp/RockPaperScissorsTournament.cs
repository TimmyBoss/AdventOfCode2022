using AdventOfCode2022.Shared;
using System.Linq;

namespace AdventOfCode2022.Day02.ConsoleApp
{
    internal class RockPaperScissorsTournament : ITask
    {
        List<Round> _tournament = new List<Round>();
        
        public long GetAnswer1()
        {
            var totalPoints = 0;

            foreach (var round in _tournament)
            {
                totalPoints += GetMovePoints(round);
                totalPoints += GetOutcomePoints(round);
            }

            return totalPoints;
        }

        public long GetAnswer2()
        {
            return 0;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _tournament = puzzleInput.Select(p => new Round(p.Split(" ")[0], p.Split(" ")[1])).ToList();

        }

        private int GetMovePoints(Round round)
        {
            switch (round.MyMove)
            {
                case "X": return 1;
                case "Y": return 2;
                case "Z": return 3;
                default: return 0;
            }
        }

        private int GetOutcomePoints(Round round)
        {
            if (round.OpponentMove == "A")
                return GetOpponentRockPoints(round);
            if (round.OpponentMove == "B")
                return GetOpponentPaperPoints(round);
            if (round.OpponentMove == "C")
                return GetOpponentScissorsPoints(round);

            return 0;
        }

        private int GetOpponentRockPoints(Round round)
        {
            if (round.MyMove == "X")
                return 3;
            if (round.MyMove == "Y")
                return 6;
            if (round.MyMove == "Z")
                return 0;

            return 0;
        }
        private int GetOpponentPaperPoints(Round round)
        {
            if (round.MyMove == "X")
                return 0;
            if (round.MyMove == "Y")
                return 3;
            if (round.MyMove == "Z")
                return 6;

            return 0;
        }

        private int GetOpponentScissorsPoints(Round round)
        {
            if (round.MyMove == "X")
                return 6;
            if (round.MyMove == "Y")
                return 0;
            if (round.MyMove == "Z")
                return 3;

            return 0;
        }
    }
}
