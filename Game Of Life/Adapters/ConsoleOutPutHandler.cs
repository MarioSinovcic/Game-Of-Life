using System;
using System.Threading;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Adapters
{
    public class ConsoleOutPutHandler : IOutputHandler
    {
        private const string AliveCell = "x";
        private const string DeadCell = "·";
        private const string Separator = "·";
        
        public void DisplayGrid(Grid grid)
        {
            Thread.Sleep(500);

            Console.Clear();
            for (var i = 0; i < grid.Width; i++)
            {
                for (var j = 0; j < grid.Height; j++)
                {
                    DisplayCell(grid.CellGrid[j, i]);
                }
                Console.WriteLine($"{Separator}\n");
            }
        }

        private void DisplayCell(Cell cell)
        { 
            Console.Write(cell.CellStatus.Equals(CellStatus.Alive) ? $"{Separator}  {AliveCell}  " : $"{Separator}  {DeadCell}  ");
        }
    }
}