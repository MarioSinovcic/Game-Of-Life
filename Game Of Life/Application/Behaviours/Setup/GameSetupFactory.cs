using System;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class GameSetupFactory
    {
        private static readonly PathNameGameSetupHandler PathNameGameSetupHandler = new PathNameGameSetupHandler();
        private static readonly RandomGameSetupHandler RandomGameSetupHandler = new RandomGameSetupHandler();

        public Grid GenerateInitialGrid(string[] args)
        {
            try
            {
                if (args is null || string.IsNullOrEmpty(args[0]))
                {
                    return RandomGameSetupHandler.CreateInitialGrid();
                }
                return PathNameGameSetupHandler.CreateInitialGrid(args[0]);
            }
            catch (IndexOutOfRangeException)
            {
                return RandomGameSetupHandler.CreateInitialGrid();
            }
        }
    }
}