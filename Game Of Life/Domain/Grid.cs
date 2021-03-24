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

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            CellGrid = new Cell[height,width];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
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