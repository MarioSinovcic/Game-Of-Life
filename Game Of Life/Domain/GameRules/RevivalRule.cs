using Game_Of_Life.Domain.Enums;
using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Domain.GameRules
{
    public class RevivalSurvivalCondition : ISurvivalCondition
    {
        public bool Evaluate(Grid grid, int y, int x)
        {
            var currentCell = grid.CellGrid[y, x];
            var aliveNeighbours = grid.GetAliveNeighbours(y, x);
            
            return currentCell.CellStatus.Equals(CellStatus.Dead) && aliveNeighbours == 3;
        }
    }
}