using System;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours
{
    public class GenerationUpdater
    {
        public Grid CreateNewGeneration(Grid grid)
        {
            var newGeneration = grid;

            for (var i = 0; i < grid.Width; i++)
            {
                for (var j = 0; j < grid.Height; j++)
                {
                    newGeneration = CheckUnderpopulationRule(grid, grid.CellGrid[j,i], j, i);
                }
            }
            return newGeneration;
        }
        
        //Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        private Grid CheckUnderpopulationRule(Grid grid, Cell cell, int y, int x)
        {
            if (cell.CellStatus.Equals(CellStatus.Dead))
            {
                return grid;
            }
            if (grid.GetAliveNeighbours(y, x) < 2)
            {
                grid.CellGrid[y, x].FlipCellStatus();
            }
            return grid;
        }
    }
}