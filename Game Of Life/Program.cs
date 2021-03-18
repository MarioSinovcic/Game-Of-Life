using Game_Of_Life.Adapters;
using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Interfaces;
using Game_Of_Life.Port;

namespace Game_Of_Life
{
    internal static class Program
    {
        private static void Main()
        {
            IGameSetup gameSetupHandler = new StringArrayGameSetupHandler();
            IOutputHandler outputHandler = new ConsoleOutPutHandler();
            IRuleFactory ruleFactory = new ClassicRuleFactory();
            
            
            var gameController = new GameController(gameSetupHandler, ruleFactory);
            var grid = gameController.SetupGame();
            

            while (true)
            {
                grid = gameController.IterateGame(grid);
                outputHandler.DisplayGrid(grid);
            }
        }
    }
}