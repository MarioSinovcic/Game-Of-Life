using System;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class RandomGameSetupHandler : IGameSetup
    {
        private const int GridWidth = 8;
        private const int GridHeight = 8;
        
        public Grid CreateInitialGrid()
        {
            var cellGrid = new Cell[GridHeight,GridWidth];
            
            for (var i = 0; i < GridWidth; i++)
            {
                for (var j = 0; j < GridHeight; j++)
                {
                    var cellStatus = GetRandomCellStatus();
                    cellGrid[j, i] = new Cell {CellStatus = cellStatus};
                }
            }
            
            return new Grid(cellGrid);
        }
        

        private CellStatus GetRandomCellStatus()
        {
            var values = Enum.GetValues(typeof(CellStatus));
            var random = new Random();
            return (CellStatus)values.GetValue(random.Next(values.Length));
        }
    }
}