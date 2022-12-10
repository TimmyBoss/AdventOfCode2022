namespace AdventOfCode2022.Shared
{
    public interface ITask
    {
        void SetupPuzzleInput(List<string> puzzleInput);
        string GetAnswer1();
        string GetAnswer2();
    }
}