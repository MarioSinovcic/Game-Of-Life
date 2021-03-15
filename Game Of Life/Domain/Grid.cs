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

        public int GetAliveNeighbours(Cell cell)
        {
            var aliveNeighbours = 0;
            if (cell.CellStatus.Equals(CellStatus.Alive))
            {
                aliveNeighbours--;
            }
            
            for (var i = -1 ; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var X = (cell.X + i + Width) % Width;
                    var Y = (cell.Y + j + Height) % Height;
                    if (CellGrid[X,Y].CellStatus.Equals(CellStatus.Alive))
                    {
                        aliveNeighbours++;
                    }
                }
            }
            return aliveNeighbours;
        }
    }
}