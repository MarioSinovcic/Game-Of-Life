using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours
{
    public class GameSetupHandler : IGameSetup
    {
        public Grid CreateInitialGrid(string [,] firstGeneration)
        {
            var gridWidth = firstGeneration.GetLength(0);
            var gridHeight = firstGeneration.GetLength(1);

            var cellGrid = new Cell[gridWidth,gridHeight];
            
            for (var i = 0; i < gridWidth; i++)
            {
                for (var j = 0; j < gridHeight; j++)
                {
                    var cellStatus = getCellStatus(firstGeneration[i,j]);
                    cellGrid[i,j] = new Cell(i,j,cellStatus);
                }
            }
            
            return new Grid(gridWidth, gridHeight, cellGrid);
        }

        private CellStatus getCellStatus(string value)
        {
            return string.Equals(value, "o") ? CellStatus.Dead : CellStatus.Alive;
        }
    }
}