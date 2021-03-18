using System;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;

namespace Game_Of_Life.Application.Behaviours
{
    public class SizeBasedRandomGameSetupHandler
    {
        public Grid CreateInitialGrid(int width, int height)
        {
            var cellGrid = new Cell[height,width];
            
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    cellGrid[j,i] = new Cell(GetRandomCellStatus());
                }
            }
            
            return new Grid(height, width, cellGrid);
        }
        

        private CellStatus GetRandomCellStatus()
        {
            var values = Enum.GetValues(typeof(CellStatus));
            var random = new Random();
            return (CellStatus)values.GetValue(random.Next(values.Length));
        }
    }
}