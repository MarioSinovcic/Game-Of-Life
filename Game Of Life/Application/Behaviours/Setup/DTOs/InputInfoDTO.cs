namespace Game_Of_Life.Application.Behaviours.Setup.DTOs
{
    public class InputInfoDTO //ask about the warnings here
    { 
        public string LiveCellChar { get; set; }
        public string DeadCellChar { get; set; }
        public string[,] InitialGrid { get; set; }
    }
}