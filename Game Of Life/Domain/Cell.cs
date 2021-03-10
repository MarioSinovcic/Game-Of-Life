namespace Game_Of_Life.Domain
{
    public class Cell
    {
        public Cell(int x, int y, CellStatus cellStatus)
        {
            X = x;
            Y = y;
            CellStatus = cellStatus;
        }
        
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public int[] Coordinates => new[] { X, Y };
        public CellStatus CellStatus { get; set; }
    }
}