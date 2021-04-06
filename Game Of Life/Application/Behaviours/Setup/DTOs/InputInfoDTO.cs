namespace Game_Of_Life.Application.Behaviours.Setup.DTOs
{
    public sealed class InputInfoDTO //should be a record
    {
        public string LiveCellChar { get; set; }
        public string DeadCellChar { get; set; }
        public string[,] InitialGrid { get; set; }
    }
}