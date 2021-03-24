using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class StringArrayGameSetupHandler : IGameSetup
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
                    cellGrid[j,i] = new Cell{CellStatus = cellStatus};
                }
            }
            
            return new Grid(cellGrid);
        }

        private CellStatus GetCellStatus(string value)
        {
            return string.Equals(value, "o") ? CellStatus.Dead : CellStatus.Alive;
        }
    }
}