namespace Game_Of_Life.Domain
{
    public class Cell
    {
        public Cell(int y, int x, CellStatus cellStatus)
        {
            Y = y;
            X = x;
            CellStatus = cellStatus;
        }
        
        public int Y { get; protected set; }
        
        public int X { get; protected set; }

        public int[] Coordinates => new[] { Y, X };
        public CellStatus CellStatus { get; set; }

        public void FlipCellStatus()
        {
            CellStatus = CellStatus switch
            {
                CellStatus.Alive => CellStatus.Dead,
                CellStatus.Dead => CellStatus.Alive,
                _ => CellStatus
            };
        }
    }
}