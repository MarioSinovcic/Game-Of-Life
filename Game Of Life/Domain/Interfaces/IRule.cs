namespace Game_Of_Life.Domain.Interfaces
{
    public interface IRule
    {
        bool Evaluate(Grid grid, int y, int x);
    }
}