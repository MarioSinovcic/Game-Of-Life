using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Port
{
    public class GameController
    {
        private readonly IGameSetup _gameSetupHandler;
        private readonly GenerationUpdater _generationUpdater;
        
        public GameController(IGameSetup gameSetupHandler, IRuleFactory ruleFactory)
        {
            _gameSetupHandler = gameSetupHandler;
            _generationUpdater = new GenerationUpdater(ruleFactory);
        }

        public Grid IterateGame(Grid grid)
        {
            if (grid is null)
            {
                return _gameSetupHandler.CreateInitialGrid(new[,] {
                    {"o", "o", "o", "o", "o", "o", "o", "o", "o", "o"}, 
                    {"o", "o", "o", "o", "o", "o", "x", "o", "o", "o"}, 
                    {"o", "o", "o", "o", "x", "o", "o", "o", "x", "o"}, 
                    {"o", "o", "o", "x", "o", "o", "o", "o", "o", "o"}, 
                    {"o", "o", "o", "x", "o", "o", "o", "o", "x", "o"}, 
                    {"o", "o", "o", "x", "x", "x", "x", "x", "o", "o"}, 
                    {"o", "o", "o", "o", "o", "o", "o", "o", "o", "o"}, 
                    {"o", "o", "o", "o", "o", "o", "o", "o", "o", "o"}, 
                    {"o", "o", "o", "o", "o", "o", "o", "o", "o", "o"}, 
                    {"o", "o", "o", "o", "o", "o", "o", "o", "o", "o"}});
            }

            var newGeneration = _generationUpdater.CreateNewGeneration(grid);
            return newGeneration;
        }
    }
}