using Game_Of_Life.Adapters;
using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Interfaces;
using Game_Of_Life.Port;

namespace Game_Of_Life
{
    class Program //TODO: implement random setup generator, integration tests (multiple generations)
    {
        private static void Main()
        {
            IGameSetup gameSetupHandler = new GameSetupHandler();
            IOutputHandler outputHandler = new ConsoleOutPutHandler();
            IRuleFactory ruleFactory = new ClassicRuleFactory();
            var gameController = new GameController(gameSetupHandler, ruleFactory);

            Grid grid = null;

            while (true)
            {
                grid = gameController.IterateGame(grid);
                outputHandler.DisplayGrid(grid);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}