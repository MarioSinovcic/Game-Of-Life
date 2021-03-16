using Game_Of_Life.Adapters;
using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Port
{
    public class GameController
    {
        private IGameSetup _gameSetupHandler;
        private IOutputHandler _outputHandler;
        private GenerationUpdater _generationUpdater = new GenerationUpdater();
        
        public GameController(IGameSetup gameSetupHandler, IOutputHandler outputHandler)
        {
            _gameSetupHandler = gameSetupHandler;
            _outputHandler = outputHandler;
        }

        public Grid IterateGame(Grid grid)
        {
            if (grid is null)
            {
                return _gameSetupHandler.CreateInitialGrid(new[,] {
                    {"x", "o", "o", "o", "x"}, 
                    {"x", "o", "x", "o", "x"}, 
                    {"x", "o", "x", "o", "x"}, 
                    {"o", "o", "x", "o", "o"}, 
                    {"o", "o", "o", "o", "o"}});
            }
            
            var newG = new Grid(grid.Height, grid.Width);
            newG = _generationUpdater.CreateNewGeneration(grid);
            return newG;
        }
    }
}