using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Interfaces
{
    public interface IGameSetup
    {
        public Grid CreateInitialGrid();
    }
}