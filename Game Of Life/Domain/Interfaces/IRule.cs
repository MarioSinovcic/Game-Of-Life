namespace Game_Of_Life.Domain.Interfaces
{
    public interface IRule
    {
        bool EvaluateRule(Grid grid, int y, int x);
    }
}