using Game_Of_Life.Domain;

namespace Game_Of_Life.Adapters
{
    public interface IOutputHandler
    {
        public void DisplayGrid(Grid grid);
    }
}