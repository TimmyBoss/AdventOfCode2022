using AdventOfCode2022.Shared;

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

                totalPoints += GetMovePoints(round.MyMove);
                totalPoints += GetOutcomePoints(round.OpponentMove, round.MyMove);
            }

            return totalPoints;
        }

        public long GetAnswer2()
        {
            var totalPoints = 0;

            foreach (var round in _tournament)
            {
                var outcomeMove = GetOutcomeMove(round);
                totalPoints += GetMovePoints(outcomeMove);
                totalPoints += GetOutcomePoints(round.OpponentMove, outcomeMove);
            }

            return totalPoints;
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            _tournament = puzzleInput.Select(p => new Round(p.Split(" ")[0], p.Split(" ")[1])).ToList();
        }

        private string GetOutcomeMove(Round round)
        {
            if (round.MyMove == "X")
            {
                if (round.OpponentMove == "A")
                    return "Z";
                if (round.OpponentMove == "B")
                    return "X";
                if (round.OpponentMove == "C")
                    return "Y";
            }

            if (round.MyMove == "Y")
            {
                if (round.OpponentMove == "A")
                    return "X";
                if (round.OpponentMove == "B")
                    return "Y";
                if (round.OpponentMove == "C")
                    return "Z";
            }

            if (round.MyMove == "Z")
            {
                if (round.OpponentMove == "A")
                    return "Y";
                if (round.OpponentMove == "B")
                    return "Z";
                if (round.OpponentMove == "C")
                    return "X";
            }

            return ""; 
        }

        private int GetMovePoints(string myMove)
        {
            switch (myMove)
            {
                case "X": return 1;
                case "Y": return 2;
                case "Z": return 3;
                default: return 0;
            }
        }

        private int GetOutcomePoints(string opponentMove, string myMove)
        {
            if (opponentMove == "A")
                return GetOpponentRockPoints(myMove);
            if (opponentMove == "B")
                return GetOpponentPaperPoints(myMove);
            if (opponentMove == "C")
                return GetOpponentScissorsPoints(myMove);

            return 0;
        }

        private int GetOpponentRockPoints(string myMove)
        {
            if (myMove == "X")
                return 3;
            if (myMove == "Y")
                return 6;
            if (myMove == "Z")
                return 0;

            return 0;
        }
        private int GetOpponentPaperPoints(string myMove)
        {
            if (myMove == "X")
                return 0;
            if (myMove == "Y")
                return 3;
            if (myMove == "Z")
                return 6;

            return 0;
        }

        private int GetOpponentScissorsPoints(string myMove)
        {
            if (myMove == "X")
                return 6;
            if (myMove == "Y")
                return 0;
            if (myMove == "Z")
                return 3;

            return 0;
        }
    }
}
