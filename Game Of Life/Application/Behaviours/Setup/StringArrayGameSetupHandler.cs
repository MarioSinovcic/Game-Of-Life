using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class StringArrayGameSetupHandler : IGameSetup
    {
        private string[,] _firstGeneration;

        public StringArrayGameSetupHandler(string[,] firstGeneration)
        {
            _firstGeneration = firstGeneration;
        }
        
        public Grid CreateInitialGrid()
        {
            var gridWidth = _firstGeneration.GetLength(1);
            var gridHeight = _firstGeneration.GetLength(0);

            var cellGrid = new Cell[gridHeight,gridWidth];
            
            for (var i = 0; i < gridWidth; i++)
            {
                for (var j = 0; j < gridHeight; j++)
                {
                    var cellStatus = GetCellStatus(_firstGeneration[j,i]);
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