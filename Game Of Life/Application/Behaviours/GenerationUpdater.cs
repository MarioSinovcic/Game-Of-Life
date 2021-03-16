using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours
{
    public class GenerationUpdater
    {
        public Grid CreateNewGeneration(Grid grid)
        {
            var newGeneration = new Grid(grid.Height, grid.Width);

            for (var i = 0; i < grid.Width; i++)
            {
                for (var j = 0; j < grid.Height; j++)
                {
                    newGeneration.CellGrid[j,i].CellStatus = CheckUnderpopulationRule(grid, j, i);
                }
            }
            return newGeneration;
        }
        
        private CellStatus CheckUnderpopulationRule(Grid grid, int y, int x)
        {
            var currentCell = grid.CellGrid[y, x];
            var aliveNeighbours = grid.GetAliveNeighbours(y,x);

            switch (currentCell.CellStatus)
            {
                case CellStatus.Alive when aliveNeighbours < 2 || aliveNeighbours > 3:
                    return grid.CellGrid[y, x].FlippedCellStatus();
                case CellStatus.Alive:
                    return grid.CellGrid[y, x].CellStatus;
                case CellStatus.Dead when aliveNeighbours == 3:
                    return grid.CellGrid[y, x].FlippedCellStatus();
                default:
                    return grid.CellGrid[y, x].CellStatus;
            }
        }
    }
}