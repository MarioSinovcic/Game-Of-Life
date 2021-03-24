namespace Game_Of_Life.Domain.Interfaces
{
    public interface ISurvivalCondition
    {
        bool Evaluate(Grid grid, int y, int x);
    }
}