using Game_Of_Life.Adapters;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Enums;
using Game_Of_Life.Domain.GameRules;
using Game_Of_Life.Domain.Interfaces;
using Game_Of_Life.Port;

namespace Game_Of_Life
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var ruleFactory = new ClassicRuleFactory();
            var outputHandler = new ConsoleOutPutHandler();

            var gameController = new GameController(ruleFactory);
            var grid = gameController.SetupGame();

            while (true)
            {
                grid = gameController.IterateGame(grid);
                outputHandler.DisplayGrid(grid);
            }
        }
    }
}