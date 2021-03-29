using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Enums;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Port
{
    public class GameController
    {
        private readonly GenerationUpdater _generationUpdater;
        
        public GameController(IRuleFactory ruleFactory)
        {
            _generationUpdater = new GenerationUpdater(ruleFactory.GetRules());
        }

        public Grid SetupGame()
        {
            return GameSetupFactory.CreateGrid(SetupType.Random);
        }

        public Grid IterateGame(Grid grid)
        {
            var newGeneration = _generationUpdater.CreateNewGeneration(grid);
            return newGeneration;
        }
    }
}