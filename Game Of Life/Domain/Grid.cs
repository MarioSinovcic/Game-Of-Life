namespace Game_Of_Life.Domain
{
    public class Grid
    {
        public Grid(int height, int width, Cell[,] cellGrid)
        {
            Height = height;
            Width = width;
            CellGrid = cellGrid;
        }
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public Cell[,] CellGrid { get; set; }
    }
}