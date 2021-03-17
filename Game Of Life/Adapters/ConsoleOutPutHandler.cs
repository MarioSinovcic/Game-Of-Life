using System;
using System.Linq;
using System.Threading;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Adapters
{
    public class ConsoleOutPutHandler : IOutputHandler
    {
        private const int MillisecondsTimeout = 200;
        
        private const string AliveCell = "X";
        private const string DeadCell = "·";
        private const string Separator = "·";
        private const string GenerationDivider = "+";
        
        public void DisplayGrid(Grid grid)
        {
            Thread.Sleep(MillisecondsTimeout);
            Console.Clear();
            DisplayGenerationDivider(grid.Width);
            
            for (var i = 0; i < grid.Height; i++)
            {
                for (var j = 0; j < grid.Width; j++)
                {
                    DisplayCell(grid.CellGrid[i, j]);
                }
                Console.WriteLine($"{Separator}\n");
            }
        }

        private void DisplayGenerationDivider(int width)
        {
            var divider = GenerationDivider;
            for (var i = 0; i < width*2; i++)
            {
                divider += $"  {GenerationDivider}";
            }
            Console.WriteLine(divider);
        }

        private void DisplayCell(Cell cell)
        { 
            Console.Write(cell.CellStatus.Equals(CellStatus.Alive) ? $"{Separator}  {AliveCell}  " : $"{Separator}  {DeadCell}  ");
        }
    }
}