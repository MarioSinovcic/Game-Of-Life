namespace Game_Of_Life.Domain
{
    public class Cell
    {
        public Cell(CellStatus cellStatus)
        {
            CellStatus = cellStatus;
        }
        
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