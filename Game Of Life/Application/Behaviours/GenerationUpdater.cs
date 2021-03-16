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
        
        //Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        private CellStatus CheckUnderpopulationRule(Grid grid, int y, int x)
        {
            var currentCell = grid.CellGrid[y, x];
            var aliveNeighbours = grid.GetAliveNeighbours(y,x);

            if (currentCell.CellStatus.Equals(CellStatus.Alive))
            {
                if (aliveNeighbours < 2 || aliveNeighbours > 3)
                {
                    return grid.CellGrid[y, x].FlippedCellStatus();
                }
            }
            return grid.CellGrid[y, x].CellStatus;
        }
    }
}