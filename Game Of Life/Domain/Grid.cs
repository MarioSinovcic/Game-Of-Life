using System.Runtime.Intrinsics.X86;

namespace Game_Of_Life.Domain
{
    public class Grid
    {
        public Grid(int height, int width, Cell[,] cellGrid) //TODO: height/width input params not needed
        {
            Height = height;
            Width = width;
            CellGrid = cellGrid;
        }
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public Cell[,] CellGrid { get; set; }

        public int GetAliveNeighbours(int y, int x)
        {
            var aliveNeighbours = 0;
            if (CellGrid[y,x].CellStatus.Equals(CellStatus.Alive))
            {
                aliveNeighbours--;
            }
            
            for (var i = -1 ; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var X = (x + i + Width) % Width;
                    var Y = (y + j + Height) % Height;
                    if (CellGrid[Y,X].CellStatus.Equals(CellStatus.Alive))
                    {
                        aliveNeighbours++;
                    }
                }
            }
            return aliveNeighbours;
        }
    }
}