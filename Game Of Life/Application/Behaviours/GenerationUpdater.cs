using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours
{
    public class GenerationUpdater
    {
        public Grid CreateNewGeneration(Grid grid)
        {
            var newGeneration = grid;

            for (var i = 0; i < grid.Height; i++)
            {
                for (var j = 0; j < grid.Width; j++)
                {
                    newGeneration = CheckUnderpopulationRule(grid, grid.CellGrid[i,j]);
                }
            }
            
            return newGeneration;
        }
        
        //Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        private Grid CheckUnderpopulationRule(Grid grid, Cell cell)
        {
            if (cell.CellStatus.Equals(CellStatus.Dead))
            {
                return grid;
            }
            if (grid.GetAliveNeighbours(cell) < 2)
            {
                grid.CellGrid[cell.X, cell.Y].FlipCellStatus();
            }
            return grid;
        }
    }
}