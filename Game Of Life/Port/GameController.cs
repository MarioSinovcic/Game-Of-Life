using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Port
{
    public class GameController
    {
        private readonly GameSetupFactory _gameSetupHandler;
        private readonly GenerationUpdater _generationUpdater;
        
        public GameController(GameSetupFactory gameSetupHandler, IRuleFactory ruleFactory)
        {
            _gameSetupHandler = gameSetupHandler;
            _generationUpdater = new GenerationUpdater(ruleFactory);
        }

        public Grid SetupGame(string[] args)
        {
            return _gameSetupHandler.GenerateInitialGrid(args);
        }

        public Grid IterateGame(Grid grid)
        {
            var newGeneration = _generationUpdater.CreateNewGeneration(grid);
            return newGeneration;
        }
    }
}