using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Domain.GameRules
{
    public class UnderpopulationRule : IRule
    {
        public bool EvaluateRule(Grid grid, int y, int x)
        {
            var currentCell = grid.CellGrid[y, x];
            var aliveNeighbours = grid.GetAliveNeighbours(y, x);
            
            return currentCell.CellStatus.Equals(CellStatus.Alive) && aliveNeighbours < 2;
        }
    }
}