using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours
{
    public class GameSetupHandler : IGameSetup
    {
        public Grid CreateInitialGrid(string [,] firstGeneration)
        {
            var gridWidth = firstGeneration.GetLength(1);
            var gridHeight = firstGeneration.GetLength(0);

            var cellGrid = new Cell[gridHeight,gridWidth];
            
            for (var i = 0; i < gridWidth; i++)
            {
                for (var j = 0; j < gridHeight; j++)
                {
                    var cellStatus = GetCellStatus(firstGeneration[j,i]);
                    cellGrid[j,i] = new Cell(i,j,cellStatus);
                }
            }
            
            return new Grid(gridWidth, gridHeight, cellGrid);
        }

        private CellStatus GetCellStatus(string value)
        {
            return string.Equals(value, "o") ? CellStatus.Dead : CellStatus.Alive;
        }
    }
}