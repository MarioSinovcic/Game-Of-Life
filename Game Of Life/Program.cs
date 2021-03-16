using Game_Of_Life.Adapters;
using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Port;

namespace Game_Of_Life
{
    class Program //TODO: implement random setup generator, implement factory for the rules, integration tests (multiple generations)
    {
        private static void Main()
        {
            IGameSetup gameSetupHandler = new GameSetupHandler();
            IOutputHandler outputHandler = new ConsoleOutPutHandler();
            var gameController = new GameController(gameSetupHandler, outputHandler);

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