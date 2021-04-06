using System;
using Game_Of_Life.Domain.Enums;

namespace Game_Of_Life.Domain
{
    public class Grid
    {
        public Grid(Cell[,] cellGrid)
        {
            Height = cellGrid.GetLength(0);
            Width = cellGrid.GetLength(1);
            CellGrid = cellGrid;
        }

        public Grid(Grid grid) //copy constructor
        {
            Height = grid.Height;
            Width = grid.Width;

            CellGrid = new Cell[Height,Width];
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    CellGrid[j,i] = new Cell{CellStatus = CellStatus.Dead};
                }
            }
        }

        public int Height { get; }
        public int Width { get; }

        public Cell[,] CellGrid { get; }

        public int GetAliveNeighbours(int y, int x)
        {
            if (y >= Height || x >= Width)
            {
                throw new IndexOutOfRangeException("The x and y co-ordinates must be within the grid object.");
            }
            
            var aliveNeighbours = 0;
            if (CellGrid[y,x].CellStatus.Equals(CellStatus.Alive))
            {
                aliveNeighbours--;
            }
            
            for (var i = -1 ; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var xcoord = (x + i + Width) % Width;
                    var ycoord = (y + j + Height) % Height;
                    if (CellGrid[ycoord,xcoord].CellStatus.Equals(CellStatus.Alive))
                    {
                        aliveNeighbours++;
                    }
                }
            }
            return aliveNeighbours;
        }
    }
}